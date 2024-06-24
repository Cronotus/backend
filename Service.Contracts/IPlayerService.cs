using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPlayerService
    {
        Task<PlayerDto> CreatePlayer(Guid userId, bool trackChanges);
    }
}
