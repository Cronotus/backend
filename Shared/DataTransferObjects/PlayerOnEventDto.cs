
namespace Shared.DataTransferObjects
{
    public record PlayerOnEventDto
    {
        public Guid InstanceId { get; init; }
        public Guid PlayerId { get; init; }
        public Guid EventId { get; init; }
    }
}
