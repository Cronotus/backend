using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Cronotus.Presentation.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EventController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns a preview of all events
        /// </summary>
        /// <response code="200">The request was successful.</response>
        /// <response code="500">There was an internal server error thus the request was unsuccessful.</response>
        /// <returns>An array of event previews</returns>
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var events = await _serviceManager.EventService.GetAllEventsAsync(trackChanges: false);
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Returns a single event by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">The request was successful and the event by the given id was returned.</response>
        /// <response code="404">The event by the given id was not found.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            try
            {
                var result = await _serviceManager.EventService.GetEventAsync(id, trackChanges: false);
                if (result is null)
                    return StatusCode(404, $"Event with id: {id} does not exist.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="eventDto"></param>
        /// <response code="201">The event was successfully created.</response>
        /// <response code="404">No sport/organizer was found to be bounded to event. Event creation failed.</response> 
        /// <response code="400">The input object was not in acceptable form causing a bad request.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> CreateEvent([FromBody] EventForCreationDto eventDto)
        {
            try
            {
                if (eventDto is null)
                    return BadRequest("EventForCreationDto object sent from client is null.");

                var createdEvent = await _serviceManager.EventService.CreateEvent(eventDto);

                return StatusCode(201, createdEvent);
            }
            catch (OrganizerNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (SportNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Deletes an event by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">The event was deleted successfully.</response>
        /// <response code="404">The event by the given id does not exist. Could not be deleted.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            try
            {
                await _serviceManager.EventService.DeleteEvent(id);
                return NoContent();
            }
            catch (EventNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Partially updates an event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <response code="204">The request was successful and the entity got updated.</response>
        /// <response code="400">The patch document was not sent correctly, the request was unsuccessful.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        /// <returns>No return object</returns>
        [HttpPatch("{id:guid}")]
        [Authorize(Roles = "Organizer")]
        public IActionResult PartiallyUpdateEvent(Guid id, [FromBody] JsonPatchDocument<EventForUpdateDto> patchDoc)
        {
            try
            {
                if (patchDoc is null)
                    return BadRequest("patchDoc object sent from client is null.");

                var result = _serviceManager.EventService.GetEventForPatch(id, trackChanges: true);
                patchDoc.ApplyTo(result.eventForUpdateDto);

                _serviceManager.EventService.SaveChangesForPatch(result.eventForUpdateDto, result.eventEntity);

                return NoContent();
            }
            catch (EventNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Signs up a player to an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="playerId"></param>
        /// <response code="201">The player has been successfully signed up to the event.</response>
        /// <response code="404">The event with the given id does not exist in the database.</response>
        /// <response code="404">The player with the given id does not exist in the database.</response>
        /// <response code="409">Could not sign up the player to the event because it has already ended and accepts no more participants.</response>
        /// <response code="409">The player has already been signed up to the event.</response>
        /// <response code="500">An internal server error occured causing the request to be unsuccessful.</response>
        /// <returns>Player id along with target event id.</returns>
        [HttpPost("{eventId:guid}/signup/{playerId:guid}")]
        [Authorize(Roles = "Player")]
        public async Task<IActionResult> SignUpPlayerToEvent(Guid eventId, Guid playerId)
        {
            try
            {
                var result = await _serviceManager.PlayerOnEventService.SignUpPlayerToEventAsync(playerId, eventId);
                return StatusCode(201, result);
            }
            catch (PlayerNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (EventNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (EventEndedException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (PlayerAlreadySignedUpToEventException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Resigns a player from an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="playerId"></param>
        /// <response code="204">The player has been successfully resigned from the event.</response>
        /// <response code="409">The player was not previously signed up to the event. Can not resign.</response>
        /// <response code="500">There was an internal server error causing the request to unsuccessful.</response>
        /// <returns>No return object</returns>
        [HttpDelete("{eventId:guid}/resign/{playerId:guid}")]
        [Authorize(Roles = "Player")]
        public async Task<IActionResult> ResignPlayerFromEvent(Guid eventId, Guid playerId)
        {
            try
            {
                await _serviceManager.PlayerOnEventService.ResignPlayerFromEventAsync(playerId, eventId);
                return NoContent();
            }
            catch (PlayerNotSignedUpException ex)
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
