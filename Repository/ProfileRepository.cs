using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProfileRepository : RepositoryBase<User>, IProfileRepository
    {
        public ProfileRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<User?> GetProfileAsync(Guid id, bool trackChanges) =>
            await FindByCondition(u => u.Id.ToString() == id.ToString(), trackChanges)
                .SingleOrDefaultAsync();
    }
}
