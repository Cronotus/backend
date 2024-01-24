using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class ProfileService : IProfileService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public ProfileService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
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
    }
}
