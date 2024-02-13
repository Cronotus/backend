
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Service
{
    internal sealed class PlayerService : IPlayerService
    {
        private readonly IRepositoryManager _repository;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PlayerService(IRepositoryManager repository, UserManager<User> userManager, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PlayerDto> CreatePlayer(Guid userId, bool trackChanges)
        {
            var userEntity = await _userManager.FindByIdAsync(userId.ToString());
            if (userEntity is null)
            {
                _logger.LogError($"User with id: {userId} does not exist in the database.");
                throw new UserNotFoundException($"User with id: ${userId} does not exist in the database.");
            }

            var playerExistsEntity = await _repository.Player.GetPlayerByUserIdAsync(userId, trackChanges);
            if (playerExistsEntity is not null)
            {
                _logger.LogError($"User with id: ${userId} is already registered as a player.");
                throw new PlayerAlreadyExistsException($"User with id: ${userId} is already registered as a player.");
            }

            var playerEntity = new Player
            {
                Id = Guid.NewGuid(),
                UserId = userId.ToString()
            };

            _repository.Player.CreatePlayer(playerEntity);
            await _repository.SaveAsync();

            var playerToReturn = new PlayerDto
            {
                Id = playerEntity.Id,
                UserId = userId
            };

            await _userManager.AddToRolesAsync(userEntity!, ["Player"]);

            return playerToReturn;
        }
    }
}
