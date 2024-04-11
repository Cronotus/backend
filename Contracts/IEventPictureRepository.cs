using Entities.Models;

namespace Contracts
{
    public interface IEventPictureRepository
    {
        Task<EventPicture?> GetByIdAsync(Guid eventPictureId, bool trackChanges);
        Task<IEnumerable<EventPicture?>> GetAllEventPicturesByEventAsync(Guid eventId, bool trackChanges);
        void CreateEventPicture(EventPicture eventPicture);
        void DeleteEventPicture(EventPicture eventPicture);
    }
}
