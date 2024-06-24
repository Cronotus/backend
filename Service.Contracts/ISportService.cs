using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ISportService
    {
        Task<SportForReturnDto> SportForReturnAsync(Guid id, bool trackChanges);
        Task<IEnumerable<SportForReturnDto>> GetAllSportsAsync(bool trackChanges);
    }
}
