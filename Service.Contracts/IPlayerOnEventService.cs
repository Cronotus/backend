
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPlayerOnEventService
    {
        Task<PlayerOnEventDto> SignUpPlayerToEventAsync(Guid playerId, Guid eventId);
        Task ResignPlayerFromEventAsync(Guid playerId, Guid eventId);
    }
}
