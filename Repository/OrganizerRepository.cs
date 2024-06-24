using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrganizerRepository : RepositoryBase<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateOrganizer(Organizer organizer) => Create(organizer);

        public async Task<Organizer?> GetOrganizerAsync(Guid id, bool trackChanges) =>
            await FindByCondition(organizer => organizer.Id.ToString() == id.ToString(), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<Organizer?> GetOrganizerByUserIdAsync(string id, bool trackChanges) =>
            await FindByCondition(organizer => organizer.UserId == id, trackChanges)
                .SingleOrDefaultAsync();

        public async Task<Organizer?> GetOrganizerByUserIdAsync(Guid userId, bool trackChanges) =>
            await FindByCondition(organizer => organizer.UserId!.ToString() == userId.ToString(), trackChanges)
                .SingleOrDefaultAsync();
    }
}
