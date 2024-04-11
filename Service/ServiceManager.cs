using AutoMapper;
using Azure.Storage.Blobs;
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
        private readonly Lazy<IOrganizerService> _organizerService;
        private readonly Lazy<ISportService> _sportService;
        private readonly Lazy<IPlayerService> _playerService;
        private readonly Lazy<IPlayerOnEventService> _playerOnEventService;
        private readonly Lazy<IEventPictureService> _eventPictureService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration, repositoryManager));
            _profileService = new Lazy<IProfileService>(() => new ProfileService(repositoryManager, mapper, logger));
            _eventService = new Lazy<IEventService>(() => new EventService(repositoryManager, logger, mapper, userManager));
            _organizerService = new Lazy<IOrganizerService>(() => new OrganizerService(repositoryManager, userManager, logger, mapper));
            _sportService = new Lazy<ISportService>(() => new SportService(repositoryManager, logger, mapper));
            _playerService = new Lazy<IPlayerService>(() => new PlayerService(repositoryManager, userManager, logger, mapper));
            _playerOnEventService = new Lazy<IPlayerOnEventService>(() => new PlayerOnEventService(repositoryManager, userManager, logger, mapper));
            _eventPictureService = new Lazy<IEventPictureService>(() => new EventPictureService(repositoryManager, logger));
        }

        public IProfileService ProfileService => _profileService.Value;
        public IEventService EventService => _eventService.Value;
        public IOrganizerService OrganizerService => _organizerService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public ISportService SportService => _sportService.Value;
        public IPlayerService PlayerService => _playerService.Value;
        public IPlayerOnEventService PlayerOnEventService => _playerOnEventService.Value;
        public IEventPictureService EventPictureService => _eventPictureService.Value;
    }
}
