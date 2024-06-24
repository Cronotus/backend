
using Entities.Models;

namespace Contracts
{
    public interface IPlayerOnEventRepository
    {
        void CreatePlayerOnEvent(PlayersOnEvent playersOnEvent);
        void DeletePlayerOnEvent(PlayersOnEvent playersOnEvent);
        Task<PlayersOnEvent?> GetPlayerOnEventByOwnIdsAsync(Guid playerId, Guid eventId, bool trackChanges);
        Task<PlayersOnEvent[]> GetPlayersOnEventByEventIdAsync(Guid eventId, bool trackChanges);
        Task<PlayersOnEvent[]> GetPlayersOnEventByPlayerIdAsync(Guid playerId, bool trackChanges);
    }
}
