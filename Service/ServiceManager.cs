using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IProfileService> _profileService;
        private readonly Lazy<IEventService> _eventService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
            _profileService = new Lazy<IProfileService>(() => new ProfileService(repositoryManager, mapper, logger));
            _eventService = new Lazy<IEventService>(() => new EventService(repositoryManager, logger, mapper));
        }

        public IProfileService ProfileService => _profileService.Value;
        public IEventService EventService => _eventService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
