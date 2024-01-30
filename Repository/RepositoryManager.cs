using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProfileRepository> _profileRepository;
        private readonly Lazy<IEventRepository> _eventRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _profileRepository = new Lazy<IProfileRepository>(() => new ProfileRepository(_repositoryContext));
            _eventRepository = new Lazy<IEventRepository>(() => new EventRepository(_repositoryContext));
        }

        public IProfileRepository Profile => _profileRepository.Value;
        public IEventRepository Event => _eventRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
