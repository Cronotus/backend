

namespace Shared.DataTransferObjects
{
    public record EventForReturnDto
    {
        public Guid Id { get; init; }
        public Guid SportId { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Location { get; init; } = null!;
        public DateTime StartDate { get; init; }
        public int capacity { get; init; }
        public bool isEnded { get; init; }
    }
}
