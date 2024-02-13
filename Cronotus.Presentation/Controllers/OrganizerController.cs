
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
        /// <response code="201">The object was created successfully.</response>
        /// <response code="400">Bad request sent. The request was not successful.</response>
        /// <response code="404">User was not found in the database by the given id.</response>
        /// <response code="409">The request was not successful because an organizer already exists with the given user id.</response>
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
            catch (UserNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Returns an organizer by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <response code="200">The request was successful.</response>
        /// <response code="404">The was no organizer found by the given user id.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        /// <returns>A single organizer.</returns>
        [HttpGet("{userId:guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetOrganizerByUserId(Guid userId)
        {
            try
            {
                var result = await _serviceManager.OrganizerService.GetOrganizerByUserIdAsync(userId, trackChanges: false);
                return Ok(result);
            }
            catch (OrganizerNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Returns events bounded by organizer id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">The request was successful.</response>
        /// <response code="404">There was no organizer found in the database by the give id.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        /// <returns>A list of event previews</returns>
        [HttpGet("{id:guid}/events")]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> GetEventsByOrganizer(Guid id)
        {
            try
            {
                var result = await _serviceManager.EventService.GetEventsByOrganizerAsync(id, trackChanges: false);
                return Ok(result);
            }
            catch (OrganizerNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            
        }
    }
}
