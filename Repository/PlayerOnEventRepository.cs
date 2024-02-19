using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PlayerOnEventRepository : RepositoryBase<PlayersOnEvent>, IPlayerOnEventRepository
    {
        public PlayerOnEventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePlayerOnEvent(PlayersOnEvent playersOnEvent) => Create(playersOnEvent);

        public void DeletePlayerOnEvent(PlayersOnEvent playersOnEvent) => Delete(playersOnEvent);

        public async Task<PlayersOnEvent?> GetPlayerOnEventByOwnIdsAsync(Guid playerId, Guid eventId, bool trackChanges) =>
            await FindByCondition(
                playerOnEvent => playerOnEvent.PlayerId.ToString() == playerId.ToString() 
                && playerOnEvent.EventId.ToString() == eventId.ToString(), trackChanges).SingleOrDefaultAsync();

        public async Task<PlayersOnEvent[]> GetPlayersOnEventByEventIdAsync(Guid eventId, bool trackChanges) =>
            await FindAll(trackChanges)
                .Where(playerOnEvent => playerOnEvent.EventId.ToString() == eventId.ToString())
                .ToArrayAsync();
    }
}
