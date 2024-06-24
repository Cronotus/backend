using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IEventService
    {
        Task<(IEnumerable<EventPreviewForReturnDto> res, MetaData metaData)> GetAllEventsAsync(EventParameters eventParameters, bool trackChanges);
        Task<IEnumerable<EventPreviewForReturnDto>> GetEventsByOrganizerAsync(Guid organizerId, bool trackChanges);
        Task<EventForReturnDto?> GetEventAsync(Guid eventId, bool trackChanges);
        Task<EventForReturnDto> CreateEvent(EventForCreationDto eventDto);
        Task DeleteEvent(Guid eventId);
        (EventForUpdateDto eventForUpdateDto, Event eventEntity) GetEventForPatch(Guid id, bool trackChanges);
        void SaveChangesForPatch(EventForUpdateDto eventToPatch, Event eventEntity);
    }
}
