
namespace Shared.DataTransferObjects
{
    public record SportForReturnDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
    }
}
