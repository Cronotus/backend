
namespace Shared.DataTransferObjects
{
    public record PlayerDto
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
    }
}
