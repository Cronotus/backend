using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(e => e.StartDate)
                .ToListAsync();
    }
}
