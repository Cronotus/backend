
namespace Shared.DataTransferObjects
{
    public record EventForCreationDto
    {
        public Guid SportId { get; init; }
        public Guid OrganizerId { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Location { get; init; } = null!;
        public DateTime StartDate { get; init; }
        public int Capacity { get; init; }
        public bool isEnded { get; init; } = false;
    }
}
