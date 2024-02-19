using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Service
{
    internal sealed class PlayerOnEventService : IPlayerOnEventService
    {
        private readonly IRepositoryManager _repository;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PlayerOnEventService(IRepositoryManager repository, UserManager<User> userManager, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task ResignPlayerFromEventAsync(Guid playerId, Guid eventId)
        {
            var playerOnEventEntity = await _repository.PlayerOnEvent.GetPlayerOnEventByOwnIdsAsync(playerId, eventId, false);
            if (playerOnEventEntity is null)
            {
                _logger.LogError($"Player with id {playerId} is not signed up to event with id {eventId}");
                throw new PlayerNotSignedUpException($"Player with id {playerId} is not signed up to event with id {eventId}");
            }

            _repository.PlayerOnEvent.DeletePlayerOnEvent(playerOnEventEntity);
            await _repository.SaveAsync();

            _logger.LogInfo($"Player with id {playerId} has been resigned from event with id {eventId}");
            return;
        }

        public async Task<PlayerOnEventDto> SignUpPlayerToEventAsync(Guid playerId, Guid eventId)
        {
            var playerEntity = await _repository.Player.GetPlayerAsync(playerId, false);
            if (playerEntity is null)
            {
                _logger.LogError($"Player with id: {playerId} does not exist in the database.");
                throw new PlayerNotFoundException($"Player with id: {playerId} does not exist in the database.");
            }

            var eventEntity = await _repository.Event.GetEventAsync(eventId, false);
            if (eventEntity is null)
            {
                _logger.LogError($"Event with id: {eventId} does not exist in the database.");
                throw new EventNotFoundException($"Event with id: {eventId} does not exist in the database.");
            }

            if (eventEntity.Ended)
            {
                _logger.LogError($"Can't sign up to event with id: {eventId}. The event has already ended.");
                throw new EventEndedException($"Can't sign up to event with id: {eventId}. The event has already ended.");
            }

            var playerOnEventEntity = await _repository.PlayerOnEvent.GetPlayerOnEventByOwnIdsAsync(playerId, eventId, false);
            if (playerOnEventEntity is not null)
            {
                _logger.LogError($"The player with id {playerId} has already been signed up to event with id {eventId}");
                throw new PlayerAlreadySignedUpToEventException($"The player with id {playerId} has already been signed up to event with id {eventId}");
            }

            var playerOnEventToCreate = new PlayersOnEvent
            {
                Id = Guid.NewGuid(),
                PlayerId = playerId,
                EventId = eventId
            };

            _repository.PlayerOnEvent.CreatePlayerOnEvent(playerOnEventToCreate);
            await _repository.SaveAsync();

            var playerOnEventToReturn = new PlayerOnEventDto
            {
                InstanceId = playerOnEventToCreate.Id,
                PlayerId = playerId,
                EventId = eventId
            };

            return playerOnEventToReturn;
        }
    }
}
