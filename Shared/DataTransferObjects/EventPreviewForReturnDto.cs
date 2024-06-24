namespace Shared.DataTransferObjects
{
    public record EventPreviewForReturnDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public DateTime StartDate { get; init; }
    }
}
