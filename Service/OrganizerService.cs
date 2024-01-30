
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Service
{
    internal sealed class OrganizerService : IOrganizerService
    {
        private readonly IRepositoryManager _repository;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrganizerService(IRepositoryManager repository, UserManager<User> userManager, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OrganizerDto> CreateOrganizer(OrganizerForCreationDto organizer)
        {
            var organizerExists = await _repository.Organizer.GetOrganizerByUserIdAsync(organizer.userId.ToString(), false);
            if (organizerExists is not null)
            {
                _logger.LogError($"Organizer with user id: {organizer.userId} already exists in the database.");
                throw new OrganizerAlreadyExistsException($"User with id: {organizer.userId} is already registered as an organizer.");
            }

            var organizerEntity = new Organizer
            {
                Id = Guid.NewGuid(),
                UserId = organizer.userId.ToString()
            };

            _repository.Organizer.CreateOrganizer(organizerEntity);
            _repository.Save();

            var organizerToReturn = new OrganizerDto
            {
                Id = organizerEntity.Id,
                UserId = new Guid(organizerEntity.UserId)
            };

            var user = await _userManager.FindByIdAsync(organizerToReturn.UserId.ToString());
            await _userManager.AddToRolesAsync(user!, ["Organizer"]);

            return organizerToReturn;
        }
    }
}
