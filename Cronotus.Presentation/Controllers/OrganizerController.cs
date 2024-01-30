
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Cronotus.Presentation.Controllers
{
    [Route("api/organizer")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrganizerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Creates a new organizer
        /// </summary>
        /// <param name="organizerDto"></param>
        /// <returns code="201">The object was created successfully.</returns>
        /// <returns code="400">Bad request sent. The request was not successful.</returns>
        /// <returns code="409">The request was not successful because an organizer already exists with the given user id.</returns>
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateOrganizer([FromBody] OrganizerForCreationDto organizerDto)
        {
            try
            {
                if (organizerDto is null)
                    return BadRequest("OrganizerForCreationDto object sent from client is null.");

                var createdOrganizer = await _serviceManager.OrganizerService.CreateOrganizer(organizerDto);

                return StatusCode(201, createdOrganizer);
            }
            catch (OrganizerAlreadyExistsException ex)
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
