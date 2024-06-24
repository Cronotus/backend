using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProfileService
    {
        Task<ProfileForReturnDto?> GetProfileAsync(Guid id, bool trackChanges);
        Task<ProfileForReturnDto?> GetProfileByOrganizerIdAsync(Guid id, bool trackChanges);
        (ProfileForUpdateDto profileToPatch, User userEntity) GetProfileForPatch(Guid id, bool trackChanges);
        Task<string?> GetProfilePictureUriAsync(Guid id);
        Task<string?> GetProfileCoverImageUriAsync(Guid id);
        Task SaveProfilePictureUri(Guid id, string? profilePictureUri);
        Task SaveConverImageUri(Guid id, string? profileCoverImageUri);
        void SaveChangesForPatch(ProfileForUpdateDto profileForUpdateDto, User userEntity);
        void DeleteProfile(Guid id, bool trackChanges);
    }
}
