
using Entities.Models;

namespace Contracts
{
    public interface IOrganizerRepository
    {
        Task<Organizer?> GetOrganizerByUserIdAsync(string id, bool trackChanges);
        Task<Organizer?> GetOrganizerAsync(Guid id, bool trackChanges);
        Task<Organizer?> GetOrganizerByUserIdAsync(Guid userId, bool trackChanges);
        void CreateOrganizer(Organizer organizer);
    }
}
