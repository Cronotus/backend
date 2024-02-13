
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Cronotus.Presentation.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PlayerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Registers a new player
        /// </summary>
        /// <param name="playerDto"></param>
        /// <response code="201">The request was successful and the user was registered as a player.</response>
        /// <response code="404">There was no user found in the database by the given id. Could not register as player.</response>
        /// <response code="409">The user by the given id is already registered as a player.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        /// <returns>No return object.</returns>
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerForCreationDto playerDto)
        {
            try
            {
                if (playerDto is null)
                    return BadRequest("PlayerForCreationDto object sent from client is null.");

                var result = await _serviceManager.PlayerService.CreatePlayer(playerDto.userId, false);

                return StatusCode(201, result);
            }
            catch (UserNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (PlayerAlreadyExistsException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
