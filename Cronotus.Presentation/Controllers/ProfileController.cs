using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace Cronotus.Presentation.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProfileController(IServiceManager service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets a profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single user profile.</returns>
        /// <response code="200">User profile returned successfully</response>
        /// <response code="404">User was not found by the given id.</response>
        /// <response code="500">An internall server error occured and the request was unsuccessful.</response>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProfile(Guid id)
        {
            try
            {
                var profile = await _service.ProfileService.GetProfileAsync(id, trackChanges: false);

                if (profile == null)
                    return StatusCode(404, $"Profile with id: {id} does not exist.");

                return Ok(profile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Partially updates a profile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns>No return object</returns>
        /// <response code="204">The request was successful and the object was partially updated.</response>
        /// <response code="400">The patch document is null, the update was not successful.</response>
        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateProfile(Guid id, [FromBody] JsonPatchDocument<ProfileForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.ProfileService.GetProfileForPatch(id, trackChanges: true);

            patchDoc.ApplyTo(result.profileToPatch);

            _service.ProfileService.SaveChangesForPatch(result.profileToPatch, result.userEntity);

            return NoContent();

        }
    }
}
