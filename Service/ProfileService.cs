using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

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
                };
                return profileToReturn;
            } 
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetProfileAsync)} method: {ex}");
                throw;
            }
        }

        public (ProfileForUpdateDto profileToPatch, User userEntity) GetProfileForPatch(Guid id, bool trackChanges)
        {   
            var profileEntity = _repositoryManager.Profile.GetProfile(id, trackChanges);

            if (profileEntity is null)
                throw new Exception($"Profile with id: {id} doesn't exist in the database.");

            var profileToPatch = _mapper.Map<ProfileForUpdateDto>(profileEntity);

            return (profileToPatch, profileEntity);
        }

        public void SaveChangesForPatch(ProfileForUpdateDto profileForUpdateDto, User userEntity)
        {
            _mapper.Map(profileForUpdateDto, userEntity);
            _repositoryManager.Save();
        }
    }
}
