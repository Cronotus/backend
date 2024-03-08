
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Exceptions;

namespace Cronotus.Presentation.Controllers
{
    [ApiController]
    [Route("api/sport")]
    [Authorize(Roles = "User")]
    public class SportController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public SportController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Returns a list of all sports
        /// </summary>
        /// <response code="200">The request was successful.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        /// <returns>All sports.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllSports()
        {
            var sports = await _serviceManager.SportService.GetAllSportsAsync(trackChanges: false);
            return Ok(sports);
        }

        /// <summary>
        /// Returns a single sport by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">The request was successful and the sport was returned.</response>
        /// <response code="404">There was no sport found by the given id.</response>
        /// <response code="500">There was an internal server error causing the request to be unsuccessful.</response>
        /// <returns>A single sport.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSport(Guid id)
        {
            var result = await _serviceManager.SportService.SportForReturnAsync(id, trackChanges: false);
            return Ok(result);
        }
    }
}
