using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Service
{
    internal sealed class ProfileService : IProfileService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ProfileService(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        public void DeleteProfile(Guid id, bool trackChanges)
        {
            var profile = _repositoryManager.Profile.GetProfile(id, trackChanges);

            if (profile is null)
                throw new Exception($"Profile with id: {id} doesn't exist in the database.");

            _repositoryManager.Profile.DeleteProfile(profile);
            _repositoryManager.Save();
        }

        public async Task<ProfileForReturnDto?> GetProfileAsync(Guid id, bool trackChanges)
        {
            try
            {
                var profile = await _repositoryManager.Profile.GetProfileAsync(id, trackChanges);
                if (profile == null)
                    return null;

                var profileToReturn = new ProfileForReturnDto
                {
                    Id = new Guid(profile.Id),
                    UserName = profile.UserName,
                    Email = profile.Email,
                    PhoneNumber = profile.PhoneNumber,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    ProfilePicture = profile.ProfilePicture,
                    ProfileCoverImage = profile.ProfileCoverImage
                };
                return profileToReturn;
            } 
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetProfileAsync)} method: {ex}");
                throw;
            }
        }

        public async Task<ProfileForReturnDto?> GetProfileByOrganizerIdAsync(Guid id, bool trackChanges)
        {
            var organizerEntity = await _repositoryManager.Organizer.GetOrganizerAsync(id, trackChanges);
            if (organizerEntity is null)
                throw new OrganizerNotFoundException($"Organizer with id: {id} doesn't exist in the database.");

            var profileEntity = await _repositoryManager.Profile.GetProfileAsync(new Guid(organizerEntity.UserId!), trackChanges);
            if (profileEntity is null)
                throw new UserNotFoundException($"User with id {organizerEntity.UserId} does not exist in the database.");

            var profileToReturn = new ProfileForReturnDto
            {
                Id = new Guid(profileEntity.Id),
                UserName = profileEntity.UserName,
                Email = profileEntity.Email,
                PhoneNumber = profileEntity.PhoneNumber,
                FirstName = profileEntity.FirstName,
                LastName = profileEntity.LastName,
                ProfilePicture = profileEntity.ProfilePicture,
                ProfileCoverImage = profileEntity.ProfileCoverImage
            };

            return profileToReturn;
        }

        public async Task<string?> GetProfileCoverImageUriAsync(Guid id)
        {
            var profileEntity = await _repositoryManager.Profile.GetProfileAsync(id, trackChanges: false);

            if (profileEntity is null)
                throw new UserNotFoundException($"User with id {id} does not exist in the database.");

            return profileEntity.ProfileCoverImage;
        }

        public (ProfileForUpdateDto profileToPatch, User userEntity) GetProfileForPatch(Guid id, bool trackChanges)
        {   
            var profileEntity = _repositoryManager.Profile.GetProfile(id, trackChanges);

            if (profileEntity is null)
                throw new Exception($"Profile with id: {id} doesn't exist in the database.");

            var profileToPatch = _mapper.Map<ProfileForUpdateDto>(profileEntity);

            return (profileToPatch, profileEntity);
        }

        public async Task<string?> GetProfilePictureUriAsync(Guid id)
        {
            var profileEntity = await _repositoryManager.Profile.GetProfileAsync(id, trackChanges: false);

            if (profileEntity is null)
                throw new UserNotFoundException($"User with id {id} does not exist in the database.");

            return profileEntity.ProfilePicture;
        }

        public void SaveChangesForPatch(ProfileForUpdateDto profileForUpdateDto, User userEntity)
        {
            _mapper.Map(profileForUpdateDto, userEntity);
            _repositoryManager.Save();
        }

        public async Task SaveConverImageUri(Guid id, string? profileCoverImageUri)
        {
            var profileEntity = _repositoryManager.Profile.GetProfile(id, trackChanges: true);

            if (profileEntity is null)
                throw new UserNotFoundException($"User with id {id} does not exist in the database.");

            profileEntity.ProfileCoverImage = profileCoverImageUri;
            await _repositoryManager.SaveAsync();
        }

        public async Task SaveProfilePictureUri(Guid id, string? profilePictureUri)
        {
            var profileEntity = _repositoryManager.Profile.GetProfile(id, trackChanges: true);

            if (profileEntity is null)
                throw new UserNotFoundException($"User with id {id} does not exist in the database.");

            profileEntity.ProfilePicture = profilePictureUri;
            await _repositoryManager.SaveAsync();
        }
    }
}
