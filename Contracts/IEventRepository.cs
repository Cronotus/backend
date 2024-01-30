using Entities.Models;

namespace Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges);
    }
}
