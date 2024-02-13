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

        public void CreateEvent(Event eventEntity) => Create(eventEntity);

        public void DeleteEvent(Event eventEntity) => Delete(eventEntity);

        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(e => e.StartDate)
                .ToListAsync();

        public Event? GetEvent(Guid eventId, bool trackChanges) => 
            FindByCondition(e => e.Id.ToString() == eventId.ToString(), trackChanges)
            .SingleOrDefault();

        public async Task<Event?> GetEventAsync(Guid eventId, bool trackChanges) =>
            await FindByCondition(e => e.Id.ToString() == eventId.ToString(), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Event>> GetEventsByOrganizerAsync(Guid organizerId, bool trackChanges) =>
            await FindByCondition(e => e.OrganizerId.ToString() == organizerId.ToString(), trackChanges)
                .OrderBy(e => e.StartDate)
                .ToListAsync();
    }
}
