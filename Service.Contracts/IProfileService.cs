using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProfileService
    {
        Task<ProfileForReturnDto?> GetProfileAsync(Guid id, bool trackChanges);
    }
}
