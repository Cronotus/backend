﻿using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
