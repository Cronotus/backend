using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;


namespace Cronotus.Presentation.Controllers
{
    [Route("api/profile")]
    [Authorize(Roles = "User")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly BlobService _blobService;
        

        public ProfileController(IServiceManager service, IConfiguration configuration)
        {
            _service = service;
            var connectionString = configuration.GetConnectionString("AzureBlobStorageConnection");
            _blobService = new BlobService(connectionString!);
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
            var profile = await _service.ProfileService.GetProfileAsync(id, trackChanges: false);

            if (profile == null)
                return StatusCode(404, $"Profile with id: {id} does not exist.");

            return Ok(profile);
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

        /// <summary>
        /// Updates the profile picture of a user. If the user already has a profile picture, the old one is deleted.
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="file">The picture file</param>
        /// <returns>URI to the new profile picture</returns>
        [HttpPut("{id:guid}/update-picture")]
        public async Task<IActionResult> UpdateProfilePicture(Guid id, [FromForm] IFormFile file)
        {
            var currentProfileUri = await _service.ProfileService.GetProfilePictureUriAsync(id);

            if (currentProfileUri is not null)
            {
                string fileName = Shared.Helpers.ExtractFileNameFromProfilePictureUri(currentProfileUri);
                await _blobService.DeleteFileAsync(fileName, id.ToString());
            }

            var newProfileUri = await _blobService.UploadFileAsync(file, id.ToString());
            await _service.ProfileService.SaveProfilePictureUri(id, newProfileUri);

            return Ok(newProfileUri);
        }

        /// <summary>
        /// Deletes the profile picture of a user. If the user does not have a profile picture, an exception is thrown.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NoProfilePictureException"></exception>
        [HttpPut("{id:guid}/delete-picture")]
        public async Task<IActionResult> DeleteProfilePicture(Guid id)
        {
            var currentProfileUri = await _service.ProfileService.GetProfilePictureUriAsync(id);

            if (currentProfileUri is null)
                throw new NoProfilePictureException($"User with id {id} does not have an active profile picture stored");

            string fileName = Shared.Helpers.ExtractFileNameFromProfilePictureUri(currentProfileUri);

            await _blobService.DeleteFileAsync(fileName, id.ToString());
            await _service.ProfileService.SaveProfilePictureUri(id, null);
            return NoContent();
        }

        /// <summary>
        /// Updates the profile cover image of a user. If the user already has a profile cover image, the old one is deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns>URI to the new cover image</returns>
        [HttpPut("{id:guid}/update-cover")]
        public async Task<IActionResult> UpdateProfileCoverImage(Guid id, [FromForm] IFormFile file)
        {
            var currentCoverUri = await _service.ProfileService.GetProfilePictureUriAsync(id);

            if (currentCoverUri is not null)
            {
                var fileName = Shared.Helpers.ExtractFileNameFromProfilePictureUri(currentCoverUri);
                await _blobService.DeleteFileAsync(fileName, id.ToString());
            }

            var newCoverUri = await _blobService.UploadFileAsync(file, id.ToString());
            await _service.ProfileService.SaveConverImageUri(id, newCoverUri);

            return Ok(newCoverUri);
        }

        /// <summary>
        /// Deletes the profile cover image of a user. If the user does not have a profile cover image, an exception is thrown.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NoProfileCoverPictureException"></exception>
        [HttpPut("{id:guid}/delete-cover")]
        public async Task<IActionResult> DeleteProfileCoverImage(Guid id)
        {
            var currentCoverUri = await _service.ProfileService.GetProfileCoverImageUriAsync(id);

            if (currentCoverUri is null)
                throw new NoProfileCoverPictureException($"User with id {id} does not have an active profile cover image stored");

            string fileName = Shared.Helpers.ExtractFileNameFromProfilePictureUri(currentCoverUri);

            await _blobService.DeleteFileAsync(fileName, id.ToString());
            await _service.ProfileService.SaveConverImageUri(id, null);
            return NoContent();
        }

        /// <summary>
        /// Deletes a profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No return object.</returns>
        /// <response code="204">The profile was deleted successfully.</response>
        /// <response code="500">There was an internal server error, the request was unsuccessful.</response>
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProfile(Guid id)
        {
            _service.ProfileService.DeleteProfile(id, trackChanges: false);
            return NoContent();
        }
    }
}
