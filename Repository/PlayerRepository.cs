
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePlayer(Player player) => Create(player);

        public async Task<Player?> GetPlayerAsync(Guid id, bool trackChanges) => 
            await FindByCondition(player => player.Id.ToString() == id.ToString(), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<Player?> GetPlayerByUserIdAsync(Guid userId, bool trackChanges) => 
            await FindByCondition(player => player.UserId!.ToString() == userId.ToString(), trackChanges)
                .SingleOrDefaultAsync();
    }
}
