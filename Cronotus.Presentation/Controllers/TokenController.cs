using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Cronotus.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        
        public TokenController(IServiceManager service) => _service = service;

        /// <summary>
        /// Creates a new token set
        /// </summary>
        /// <param name="tokenDto"></param>
        /// <returns>TokenDto object containing an acces token and a refresh token.</returns>
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody]TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);
        }
    }
}
