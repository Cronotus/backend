using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service;
using Service.Contracts;

namespace Cronotus.Presentation.Controllers
{
    [ApiController]
    [Route("api/blob")]
    // [Authorize(Roles = "User")]
    public class BlobController : ControllerBase
    {
        private readonly BlobService _blobService;

        public BlobController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AzureBlobStorageConnection");
            _blobService = new BlobService(connectionString!);
        }

        /// <summary>
        /// Gets all blob names in a container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns>A list of the available blob names</returns>
        [HttpGet("{containerName}")]
        public async Task<IActionResult> GetAllBlobNames(string containerName)
        {
            var blobNames = await _blobService.GetAllBlobNamesAsync(containerName);
            return Ok(blobNames);
        }

        /// <summary>
        /// Uploads an image to a container
        /// </summary>
        /// <param name="file"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        [HttpPost("{containerName}")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, string containerName)
        {
            var blobName = await _blobService.UploadFileAsync(file, containerName);
            return Ok(blobName);
        }

        [HttpDelete("{containerName}/{fileName}")]
        public async Task<IActionResult> DeleteImage(string fileName, string containerName)
        {
            await _blobService.DeleteFileAsync(fileName, containerName);
            return NoContent();
        }
    }
}
