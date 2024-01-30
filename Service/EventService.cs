using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

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

        public async Task<IEnumerable<EventPreviewForReturnDto>> GetAllEventsAsync(bool trackChanges)
        {
            try
            {
                var events = await _repository.Event.GetAllEventsAsync(trackChanges);
                var eventsDto = _mapper.Map<IEnumerable<EventPreviewForReturnDto>>(events);

                return eventsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllEventsAsync)} method: {ex}");
                throw;
            }
        }
    }
}
