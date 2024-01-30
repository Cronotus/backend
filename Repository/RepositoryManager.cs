﻿using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProfileRepository> _profileRepository;
        private readonly Lazy<IEventRepository> _eventRepository;
        private readonly Lazy<IOrganizerRepository> _organizerRepository;
        private readonly Lazy<ISportRepositry> _sportRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _profileRepository = new Lazy<IProfileRepository>(() => new ProfileRepository(_repositoryContext));
            _eventRepository = new Lazy<IEventRepository>(() => new EventRepository(_repositoryContext));
            _organizerRepository = new Lazy<IOrganizerRepository>(() => new OrganizerRepository(_repositoryContext));
            _sportRepository = new Lazy<ISportRepositry>(() => new SportRepository(_repositoryContext));
        }

        public IProfileRepository Profile => _profileRepository.Value;
        public IEventRepository Event => _eventRepository.Value;
        public IOrganizerRepository Organizer => _organizerRepository.Value;
        public ISportRepositry Sport => _sportRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
