using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProfileService
    {
        Task<ProfileForReturnDto?> GetProfileAsync(Guid id, bool trackChanges);
        (ProfileForUpdateDto profileToPatch, User userEntity) GetProfileForPatch(Guid id, bool trackChanges);
        void SaveChangesForPatch(ProfileForUpdateDto profileForUpdateDto, User userEntity);
        void DeleteProfile(Guid id, bool trackChanges);
    }
}
