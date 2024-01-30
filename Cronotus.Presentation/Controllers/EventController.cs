using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
        /// <returns code="200">The request was successful.</returns>
        /// <returns code="500">There was an internal server error thus the request was unsuccessful.</returns>
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
    }
}
