using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventPictureRepository : RepositoryBase<EventPicture>, IEventPictureRepository
    {

        public EventPictureRepository(RepositoryContext repository) : base(repository)
        {
        }

        public void CreateEventPicture(EventPicture eventPicture) => Create(eventPicture);

        public void DeleteEventPicture(EventPicture eventPicture) => Delete(eventPicture);

        public async Task<IEnumerable<EventPicture?>> GetAllEventPicturesByEventAsync(Guid eventId, bool trackChanges) =>
            await FindByCondition(e => e.EventId.ToString() == eventId.ToString(), trackChanges)
                .ToListAsync();

        public async Task<EventPicture?> GetByIdAsync(Guid eventPictureId, bool trackChanges) => 
            await FindByCondition(e => e.Id.ToString() == eventPictureId.ToString(), trackChanges)
                .SingleOrDefaultAsync();
    }
}
