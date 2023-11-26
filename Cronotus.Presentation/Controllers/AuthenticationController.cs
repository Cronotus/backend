using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Cronotus.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="userForRegistration"></param>
        /// <response code="201">User created successfully</response>
        /// <response code="400">A bad request was sent and user creation was unsuccessfull</response>
        [HttpPost("register")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <param name="userForAuthentication"></param>
        /// <response code="200">Login was successfull</response>
        /// <response code="401">The credentials were incorrect thus the login failed</response>
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(TokenDto))]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var result = await _service.AuthenticationService.ValidateUser(userForAuthentication);
            if (!result)
            {
                return Unauthorized();
            }

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }
    }
}
