using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Shared.Exceptions;
using Microsoft.Extensions.Primitives;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private User? _user;

        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _repository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IRepositoryManager repository) 
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password ?? "");
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, ["User"]);
            }

            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
        {
            _user = await _userManager.FindByNameAsync(userForAuthentication.UserName ?? "");

            var result = (_user != null) && await _userManager.CheckPasswordAsync(_user, userForAuthentication.Password ?? "");
            if (!result)
            {
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            }

            return result;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user!.RefreshToken = refreshToken;

            if (populateExp)
            {
                _user!.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            }

            await _userManager.UpdateAsync(_user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto(accessToken, refreshToken); 
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET") ?? "");
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user?.UserName ?? "")
            };

            var id = await _userManager.GetUserIdAsync(_user!);
            if (!string.IsNullOrWhiteSpace(id))
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, id));
            }

            var organizerEntity = await _repository.Organizer.GetOrganizerByUserIdAsync(id, false);
            if (organizerEntity is not null)
            {
                claims.Add(new Claim("OrganizerNameIdentifier", organizerEntity.Id.ToString()));
            }

            var playerEntity = await _repository.Player.GetPlayerByUserIdAsync(new Guid(id), false);
            if (playerEntity is not null)
            {
                claims.Add(new Claim("PlayerNameIdentifier", playerEntity.Id.ToString()));
            }

            var roles = await _userManager.GetRolesAsync(_user!);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings.GetSection("validIssuer").Value ?? "CronotusAPI",
                audience: jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                ValidAudience = jwtSettings.GetSection("validAudience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET") ?? ""))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if ((jwtSecurityToken == null) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetClaimsPrincipalFromExpiredToken(tokenDto.AccessToken);

            var user = await _userManager.FindByNameAsync(principal.Identity!.Name!);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new SecurityTokenException("Invalid token. The tokenDto has some invalid values.");
            }

            _user = user;

            return await CreateToken(populateExp: false);
        }

        public async Task<Guid> CheckForPlayerRole(StringValues accessToken)
        {
            string accessTokenString = accessToken!;
            accessTokenString = accessTokenString.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessTokenString);

            var playerIdentifier = token.Claims.FirstOrDefault(c => c.Type == "PlayerNameIdentifier")?.Value;
            if (playerIdentifier is not null)
                return new Guid(playerIdentifier);

            var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Player newPlayer = new Player
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            _repository.Player.CreatePlayer(newPlayer);
            await _repository.SaveAsync();

            var userEntity = await _userManager.FindByIdAsync(userId!);
            await _userManager.AddToRolesAsync(userEntity!, ["Player"]);
            
            return newPlayer.Id;
        }

        public async Task<Guid> CheckForOrganizerRole(StringValues accessToken)
        {
            string accessTokenString = accessToken!;
            accessTokenString = accessTokenString.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessTokenString);

            var organizerIdentifier = token.Claims.FirstOrDefault(c => c.Type == "OrganizerNameIdentifier")?.Value;
            if (organizerIdentifier is not null)
                return new Guid(organizerIdentifier);

            var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            Organizer newOrganizer = new Organizer
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            _repository.Organizer.CreateOrganizer(newOrganizer);
            await _repository.SaveAsync();

            var userEntity = await _userManager.FindByIdAsync(userId!);
            await _userManager.AddToRolesAsync(userEntity!, ["Organizer"]);

            return newOrganizer.Id;
        }
    }
}
