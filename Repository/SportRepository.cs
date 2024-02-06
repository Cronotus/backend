
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SportRepository : RepositoryBase<Sport>, ISportRepositry
    {
        public SportRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Sport?> GetSportAsync(Guid id, bool trackChanges) =>
            await FindByCondition(sport => sport.Id.ToString() == id.ToString(), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Sport>> GetSportsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(sport => sport.Name)
                .ToListAsync();
    }
}
