using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IEventRepository
    {
        Task<PagedList<Event>> GetAllEventsAsync(EventParameters eventParameters, bool trackChanges);
        Task<IEnumerable<Event>> GetEventsByOrganizerAsync(Guid organizerId, bool trackChanges);
        Task<Event?> GetEventAsync(Guid eventId, bool trackChanges);
        Event? GetEvent(Guid eventId, bool trackChanges);
        void CreateEvent(Event eventEntity);
        void DeleteEvent(Event eventEntity);
    }
}
