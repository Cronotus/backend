using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;
using Shared.RequestFeatures;

namespace Service
{
    internal sealed class EventService : IEventService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public EventService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<EventForReturnDto> CreateEvent(EventForCreationDto eventDto)
        {
            var organizerEntity = await _repository.Organizer.GetOrganizerAsync(eventDto.OrganizerId, false);
            if (organizerEntity is null)
            {
                throw new OrganizerNotFoundException($"Organizer with id: {eventDto.OrganizerId} doesn't exist in the database.");
            }

            var sportEntity = await _repository.Sport.GetSportAsync(eventDto.SportId, false);
            if (sportEntity is null)
            {
                throw new SportNotFoundException($"Sport with id: {eventDto.SportId} doesn't exist in the database.");
            }

            var eventEntity = new Event
            {
                Id = Guid.NewGuid(),
                OrganizerId = eventDto.OrganizerId,
                SportId = eventDto.SportId,
                Name = eventDto.Name,
                Location = eventDto.Location,
                StartDate = eventDto.StartDate,
                Capacity = eventDto.Capacity,
                Ended = eventDto.isEnded,
                Description = eventDto.Description
            };

            _repository.Event.CreateEvent(eventEntity);
            _repository.Save();

            var playerEntity = await _repository.Player.GetPlayerByUserIdAsync(new Guid(organizerEntity.UserId!), false);
            if (playerEntity is null)
                throw new PlayerNotFoundException($"Player with id: {organizerEntity.UserId} doesn't exist in the database.");

            var playerOnEventEntity = new PlayersOnEvent
            {
                Id = Guid.NewGuid(),
                PlayerId = playerEntity.Id,
                EventId = eventEntity.Id
            };

            _repository.PlayerOnEvent.CreatePlayerOnEvent(playerOnEventEntity);
            _repository.Save();

            var result = new EventForReturnDto
            {
                Id = eventEntity.Id,
                SportId = eventEntity.SportId,
                OrganizerId = eventEntity.OrganizerId,
                Name = eventEntity.Name!,
                StartDate = eventEntity.StartDate,
                capacity = eventEntity.Capacity,
                isEnded = eventEntity.Ended,
                Description = eventEntity.Description!,
                Location = eventEntity.Location!
            };

            return result;
        }

        public async Task DeleteEvent(Guid eventId)
        {
            var eventEntity = await _repository.Event.GetEventAsync(eventId, false);
            if (eventEntity is null)
            {
                throw new EventNotFoundException($"Event with id: {eventId} doesn't exist in the database.");
            }

            var playersRegisteredToEvent = await _repository.PlayerOnEvent.GetPlayersOnEventByEventIdAsync(eventId, true);
            foreach (var p in playersRegisteredToEvent)
            {
                _repository.PlayerOnEvent.DeletePlayerOnEvent(p);
            }

            _repository.Event.DeleteEvent(eventEntity);
            _repository.Save();
        }

        public async Task<(IEnumerable<EventPreviewForReturnDto> res, MetaData metaData)> GetAllEventsAsync(EventParameters eventParameters, bool trackChanges)
        {
            if (!eventParameters.validDatesRange)
            {
                throw new InvalidDateRangeException("Invalid date range. The start date must be less than the end date.");
            }
            var eventsWithMetaData = await _repository.Event.GetAllEventsAsync(eventParameters, false);

            var result = new List<EventPreviewForReturnDto>();
            foreach(var e in eventsWithMetaData)
            {
                var temp = new EventPreviewForReturnDto
                {
                    Id = e.Id,
                    Name = e.Name!,
                    StartDate = e.StartDate,
                };
                result.Add(temp);
            }

            return (res: result, metaData: eventsWithMetaData.MetaData);
        }

        public async Task<EventForReturnDto?> GetEventAsync(Guid eventId, bool trackChanges)
        {
            var eventEntity = await _repository.Event.GetEventAsync(eventId, trackChanges);
            if (eventEntity is null)
            {
                throw new EventNotFoundException($"Event with id: {eventId} doesn't exist in the database.");
            }

            var playersSingedUpEntities = await _repository.PlayerOnEvent.GetPlayersOnEventByEventIdAsync(eventEntity.Id, trackChanges);
            var playersSingedUp = playersSingedUpEntities.Count();

            var sportEntity = await _repository.Sport.GetSportAsync(eventEntity.SportId, trackChanges);
            if (sportEntity is null)
                throw new SportNotFoundException($"Sport with id: {eventEntity.SportId} doesn't exist in the database.");

            var organizerEntity = await _repository.Organizer.GetOrganizerAsync(eventEntity.OrganizerId, trackChanges);
            if (organizerEntity is null)
                throw new OrganizerNotFoundException($"Organizer with id: {eventEntity.OrganizerId} doesn't exist in the database.");

            var userEntity = await _userManager.FindByIdAsync(organizerEntity.UserId!);
            if (userEntity is null)
                throw new UserNotFoundException($"User with id: {eventEntity.OrganizerId} doesn't exist in the database.");

            var result = new EventForReturnDto
            {
                Id = eventEntity.Id,
                SportId = eventEntity.SportId,
                SportName = sportEntity.Name,
                OrganizerId = eventEntity.OrganizerId,
                OrganizerName = userEntity.UserName,
                Name = eventEntity.Name!,
                StartDate = eventEntity.StartDate,
                SignedUpPlayers = playersSingedUp,
                capacity = eventEntity.Capacity,
                isEnded = eventEntity.Ended,
                Description = eventEntity.Description!,
                Location = eventEntity.Location!
            };
            return result;
        }

        public (EventForUpdateDto eventForUpdateDto, Event eventEntity) GetEventForPatch(Guid id, bool trackChanges)
        {
            var eventEntity = _repository.Event.GetEvent(id, trackChanges);
            if (eventEntity is null)
            {
                throw new EventNotFoundException($"Event with id: {id} doesn't exist in the database.");
            }

            var eventToPatch = _mapper.Map<EventForUpdateDto>(eventEntity);
            return (eventToPatch, eventEntity);
        }

        public async Task<IEnumerable<EventPreviewForReturnDto>> GetEventsByOrganizerAsync(Guid organizerId, bool trackChanges)
        {
            var organizerEntity = await _repository.Organizer.GetOrganizerAsync(organizerId, trackChanges);
            if (organizerEntity is null)
            {
                throw new OrganizerNotFoundException($"Organizer with id: {organizerId} doesn't exist in the database.");
            }

            var eventEntitis = await _repository.Event.GetEventsByOrganizerAsync(organizerId, trackChanges);
            var result = new List<EventPreviewForReturnDto>();
            foreach (var e in eventEntitis)
            {
                var temp = new EventPreviewForReturnDto
                {
                    Id = e.Id,
                    Name = e.Name!,
                    StartDate = e.StartDate,
                };
                result.Add(temp);
            }

            return result;
        }

        public void SaveChangesForPatch(EventForUpdateDto eventToPatch, Event eventEntity)
        {
            _mapper.Map(eventToPatch, eventEntity);
            _repository.Save();
        }
    }
}
