using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<Guid> CheckForPlayerRole(StringValues accessToken);
        Task<Guid> CheckForOrganizerRole(StringValues accessToken);
    }
}
