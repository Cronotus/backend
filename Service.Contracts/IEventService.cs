using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventPreviewForReturnDto>> GetAllEventsAsync(bool trackChanges);
        Task<EventForReturnDto?> GetEventAsync(Guid eventId, bool trackChanges);
        Task<EventForReturnDto> CreateEvent(EventForCreationDto eventDto);
        Task DeleteEvent(Guid eventId);
    }
}
