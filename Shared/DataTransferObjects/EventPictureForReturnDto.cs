namespace Shared.DataTransferObjects
{
    public record EventPictureForReturnDto
    {
        public Guid Id { get; init; }
        public Guid EventId { get; init; }
        public string? PictureUrl { get; init; }
    }
}
