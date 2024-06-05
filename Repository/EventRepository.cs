using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEvent(Event eventEntity) => Create(eventEntity);

        public void DeleteEvent(Event eventEntity) => Delete(eventEntity);

        public async Task<PagedList<Event>> GetAllEventsAsync(EventParameters eventParameters, bool trackChanges)
        {
            var events = await FindAll(trackChanges)
                .OrderBy(e => e.StartDate)
                .ToListAsync();

            return PagedList<Event>.ToPagedList(events, eventParameters.PageNumber, eventParameters.PageSize);
        }

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
