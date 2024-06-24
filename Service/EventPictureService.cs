using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Service
{
    internal sealed class EventPictureService : IEventPictureService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public EventPictureService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public void CreateEventPicture(EventPictureForCreationDto eventPictureForCreationDto)
        {
            var eventPictureToCreate = new EventPicture
            {
                Id = Guid.NewGuid(),
                EventId = eventPictureForCreationDto.EventId,
                PictureUrl = eventPictureForCreationDto.PictureUrl,
            };

            _repositoryManager.EventPicture.CreateEventPicture(eventPictureToCreate);
            _repositoryManager.Save();
        }

        public async Task DeleteEventPicture(Guid eventPictureId)
        {
            var eventPictureEntity = await _repositoryManager.EventPicture.GetByIdAsync(eventPictureId, true);
            if (eventPictureEntity is null)
                throw new EventPictureNotFoundException($"EventPicture entity by id: {eventPictureId} does not exist in the database.");

            _repositoryManager.EventPicture.DeleteEventPicture(eventPictureEntity);
            _repositoryManager.Save();
            return;
        }

        public async Task<IEnumerable<EventPictureForReturnDto>> GetAllEventPicturesAsync(Guid eventId)
        {
            var eventEntity = await _repositoryManager.Event.GetEventAsync(eventId, false);
            if (eventEntity is null)
                throw new EventNotFoundException($"Event by id: {eventId} does not exist in the database.");

            var eventPictureEntities = await _repositoryManager.EventPicture.GetAllEventPicturesByEventAsync(eventId, false);
            
            var result = new List<EventPictureForReturnDto>();
            foreach (var eventPictureEntity in eventPictureEntities)
            {
                var newEventPictureToReturnDto = new EventPictureForReturnDto
                {
                    Id = eventPictureEntity!.Id,
                    EventId = eventPictureEntity.EventId,
                    PictureUrl = eventPictureEntity.PictureUrl,
                };
                result.Add(newEventPictureToReturnDto);
            }

            return result;
        }

        public async Task<EventPictureForReturnDto> GetEventPictureAsync(Guid eventPictureId)
        {
            var eventPictureEntity = await _repositoryManager.EventPicture.GetByIdAsync(eventPictureId, false);
            if (eventPictureEntity is null)
                throw new EventPictureNotFoundException($"EventPicture entity by id: {eventPictureId} does not exist in the database.");

            var eventPictureToReturnDto = new EventPictureForReturnDto
            {
                Id = eventPictureEntity.Id,
                EventId = eventPictureEntity.EventId,
                PictureUrl = eventPictureEntity.PictureUrl,
            };

            return eventPictureToReturnDto;
        }
    }
}
