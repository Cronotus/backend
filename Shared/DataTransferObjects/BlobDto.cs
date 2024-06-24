using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects
{
    public record BlobDto
    {
        public IFormFile file { get; init; } = null!;
        public string containerName { get; init; } = "";
    }
}
