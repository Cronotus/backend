using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;
using Shared.RequestFeatures;
using System.Text.Json;

namespace Cronotus.Presentation.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly BlobService _blobService;

        public EventController(IServiceManager serviceManager, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            var connectionString = configuration.GetConnectionString("AzureBlobStorageConnection");
            _blobService = new BlobService(connectionString!);
        }

        /// <summary>
        /// Returns a preview of all events
        /// </summary>
        /// <response code="200">The request was successful.</response>
        /// <response code="500">There was an internal server error thus the request was unsuccessful.</response>
        /// <returns>An array of event previews</returns>
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllEvents([FromQuery] EventParameters eventParameters)
        {
            var pagedResult = await _serviceManager.EventService.GetAllEventsAsync(eventParameters, trackChanges: false);
            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.res);
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
            var result = await _serviceManager.EventService.GetEventAsync(id, trackChanges: false);
            return Ok(result);
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
            if (eventDto is null)
                return BadRequest("EventForCreationDto object sent from client is null.");
                
            var createdEvent = await _serviceManager.EventService.CreateEvent(eventDto);
            return StatusCode(201, createdEvent);
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
            await _serviceManager.EventService.DeleteEvent(id);
            return NoContent();
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
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _serviceManager.EventService.GetEventForPatch(id, trackChanges: true);
            patchDoc.ApplyTo(result.eventForUpdateDto);

            _serviceManager.EventService.SaveChangesForPatch(result.eventForUpdateDto, result.eventEntity);

            return NoContent();
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
            var result = await _serviceManager.PlayerOnEventService.SignUpPlayerToEventAsync(playerId, eventId);
            return StatusCode(201, result);
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
            await _serviceManager.PlayerOnEventService.ResignPlayerFromEventAsync(playerId, eventId);
            return NoContent();
        }

        /// <summary>
        /// Checks if a player is registered to a given event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="playerId"></param>
        /// <response code="200">Registration was checked and a flag was returned correspondingly.</response>
        /// <response code="404">The event by the given id does not exist in the database.</response>
        /// <response code="404">The player by the given id does not exist in the database.</response>
        /// <response code="500">An internal server error occured causing the request to be unsucessful.</response>
        /// <returns>A true flag with logical value.</returns>
        [HttpGet("{eventId:guid}/check/{playerId:guid}")]
        public async Task<IActionResult> CheckIfPlayerIsSignedUp(Guid eventId, Guid playerId)
        {
            var result = await _serviceManager.PlayerOnEventService.CheckIfPlayerIsOnEvent(eventId, playerId);
            return Ok(result);
        }

        /// <summary>
        /// Uploads multiple pictures to blob storage for a given event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="files"></param>
        /// <returns>No return type</returns>
        /// <exception cref="BlobFileNullException"></exception>
        [HttpPost("{eventId:guid}/upload-pictures")]
        public async Task<IActionResult> UploadPicturesToEvent(Guid eventId, [FromForm] IFormFileCollection files)
        {
            var eventEntity = await _serviceManager.EventService.GetEventAsync(eventId, trackChanges: true);
            if (eventEntity is null)
                throw new EventNotFoundException($"Event by id: {eventId} does not exist in the database.");

            if (files.Count == 0)
                throw new BlobFileNullException("No files were uploaded.");

            foreach (var file in files)
            {
                var currentUrl = await _blobService.UploadFileAsync(file, eventId.ToString());
                var eventPictureToCreate = new EventPictureForCreationDto
                {
                    EventId = eventId,
                    PictureUrl = currentUrl
                };
                _serviceManager.EventPictureService.CreateEventPicture(eventPictureToCreate);
            }

            return NoContent();
        }

        /// <summary>
        /// Gets all pictures for a given event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>A list of the pictures for the corresponding event</returns>
        [HttpGet("{eventId:guid}/pictures")]
        public async Task<IActionResult> GetPicturesForEvent(Guid eventId)
        {
            var result = await _serviceManager.EventPictureService.GetAllEventPicturesAsync(eventId);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a picture for a given event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="eventPictureId"></param>
        /// <returns>No return type</returns>
        /// <exception cref="EventPictureNotFoundException"></exception>
        [HttpDelete("{eventId:guid}/picture/{eventPictureId:guid}")]
        public async Task<IActionResult> DeletePictureForEvent(Guid eventId, Guid eventPictureId)
        {
            var eventPictureToDelete = await _serviceManager.EventPictureService.GetEventPictureAsync(eventPictureId);
            if (eventPictureToDelete is null)
                throw new EventPictureNotFoundException($"EventPicture by id: {eventPictureId} does not exist in the database.");

            var fileName = Shared.Helpers.ExtractFileNameFromProfilePictureUri(eventPictureToDelete.PictureUrl!);

            await _blobService.DeleteFileAsync(fileName, eventId.ToString());
            await _serviceManager.EventPictureService.DeleteEventPicture(eventPictureId);

            return NoContent();
        }
    }
}
