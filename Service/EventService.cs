﻿using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Service
{
    internal sealed class EventService : IEventService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EventService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
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

            _repository.Event.DeleteEvent(eventEntity);
            _repository.Save();
        }

        public async Task<IEnumerable<EventPreviewForReturnDto>> GetAllEventsAsync(bool trackChanges)
        {
            try
            {
                var events = await _repository.Event.GetAllEventsAsync(trackChanges);

                var result = new List<EventPreviewForReturnDto>();
                foreach(var e in events)
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
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllEventsAsync)} method: {ex}");
                throw;
            }
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

            var result = new EventForReturnDto
            {
                Id = eventEntity.Id,
                SportId = eventEntity.SportId,
                SportName = sportEntity.Name,
                OrganizerId = eventEntity.OrganizerId,
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
