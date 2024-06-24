namespace Shared.RequestFeatures
{
    public class EventParameters : RequestParameters
    {
        public Guid? SportId { get; set; } = null;
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;

        public bool validDatesRange => EndDate >= StartDate;
    }
}
