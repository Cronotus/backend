namespace Service.Contracts
{
    public record EventPictureForCreationDto
    {
        public Guid EventId { get; init; }
        public string? PictureUrl { get; init; }
    }
}