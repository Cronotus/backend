using System.Text.Json;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; init; }
        public string? Message { get; init; } = null!;
        public override string ToString() =>
            JsonSerializer.Serialize(this);
    }
}
