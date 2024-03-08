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

        public async Task<PlayerSignedUpFlagForEventDto> CheckIfPlayerIsOnEvent(Guid eventId, Guid playerId)
        {
            var eventEntity = await _repository.Event.GetEventAsync(eventId, false);
            if (eventEntity is null)
            {
                throw new EventNotFoundException($"Event with id {eventId} does not exist in the database.");
            }

            var playerEntity = await _repository.Player.GetPlayerAsync(playerId, false);
            if (playerEntity is null)
            {
                throw new PlayerNotFoundException($"Player with id {playerId} does not exist in the database.");
            }

            var playerOnEventEntity = await _repository.PlayerOnEvent.GetPlayerOnEventByOwnIdsAsync(playerId, eventId, false);
            if (playerOnEventEntity is not null)
            {
                var result = new PlayerSignedUpFlagForEventDto
                {
                    IsSignedUp = true
                };
                return result;
            } else
            {
                var result = new PlayerSignedUpFlagForEventDto
                {
                    IsSignedUp = false
                };
                return result;
            }
        }

        public async Task<IEnumerable<EventPreviewForReturnDto>> GetEventPreviewsThatPlayerSignedUpToAsync(Guid playerId)
        {
            var playerEntity = _repository.Player.GetPlayerAsync(playerId, false);
            if (playerEntity is null)
            {
                throw new PlayerNotFoundException($"Player with id {playerId} does not exist in the database.");
            }

            var playerOnEventEntities = await _repository.PlayerOnEvent.GetPlayersOnEventByPlayerIdAsync(playerId, false);

            var result = new List<EventPreviewForReturnDto>();
            foreach (var playerOnEventEntity in playerOnEventEntities)
            {
                var currentEventEntity = await _repository.Event.GetEventAsync(playerOnEventEntity.EventId, false);
                var eventPreviewDto = new EventPreviewForReturnDto
                {
                    Id = playerOnEventEntity.EventId,
                    Name = currentEventEntity!.Name!,
                    StartDate = currentEventEntity.StartDate
                };
                result.Add(eventPreviewDto);
            }

            return result;
        }

        public async Task ResignPlayerFromEventAsync(Guid playerId, Guid eventId)
        {
            var playerOnEventEntity = await _repository.PlayerOnEvent.GetPlayerOnEventByOwnIdsAsync(playerId, eventId, false);
            if (playerOnEventEntity is null)
            {
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
                throw new PlayerNotFoundException($"Player with id: {playerId} does not exist in the database.");
            }

            var eventEntity = await _repository.Event.GetEventAsync(eventId, false);
            if (eventEntity is null)
            {
                throw new EventNotFoundException($"Event with id: {eventId} does not exist in the database.");
            }

            if (eventEntity.Ended)
            {
                throw new EventEndedException($"Can't sign up to event with id: {eventId}. The event has already ended.");
            }

            var playerOnEventEntity = await _repository.PlayerOnEvent.GetPlayerOnEventByOwnIdsAsync(playerId, eventId, false);
            if (playerOnEventEntity is not null)
            {
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
