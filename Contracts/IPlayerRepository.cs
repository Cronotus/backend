
using Entities.Models;

namespace Contracts
{
    public interface IPlayerRepository
    {
        void CreatePlayer(Player player);
        Task<Player?> GetPlayerByUserIdAsync(Guid userId, bool trackChanges);
        Task<Player?> GetPlayerAsync(Guid id, bool trackChanges);
    }
}
