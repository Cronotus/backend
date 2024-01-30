
namespace Shared.DataTransferObjects
{
    public record OrganizerDto
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
    }
}
