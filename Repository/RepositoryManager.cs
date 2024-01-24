using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProfileRepository> _profileRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _profileRepository = new Lazy<IProfileRepository>(() => new ProfileRepository(_repositoryContext));
        }

        public IProfileRepository Profile => _profileRepository.Value;
        public void Save() => _repositoryContext.SaveChanges(); 
    }
}
