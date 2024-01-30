using Entities.Models;

namespace Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges);
        Task<Event?> GetEventAsync(Guid eventId, bool trackChanges);
        void CreateEvent(Event eventEntity);
        void DeleteEvent(Event eventEntity);
    }
}
