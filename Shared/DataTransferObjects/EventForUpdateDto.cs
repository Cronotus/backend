
namespace Shared.DataTransferObjects
{
    public record EventForUpdateDto
    {
        public Guid SportId { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? Location { get; init; }
        public DateTime StartDate { get; init; }
        public int Capacity { get; init; }
        public bool isEnded { get; init; }

    }
}
