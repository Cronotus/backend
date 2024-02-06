using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Exceptions;

namespace Service
{
    internal sealed class SportService : ISportService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SportService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SportForReturnDto>> GetAllSportsAsync(bool trackChanges)
        {
            var sportEntities = await _repository.Sport.GetSportsAsync(trackChanges);
            var sports = _mapper.Map<IEnumerable<SportForReturnDto>>(sportEntities);
            return sports;
        }

        public async Task<SportForReturnDto> SportForReturnAsync(Guid id, bool trackChanges)
        {
            var sportEntity = await _repository.Sport.GetSportAsync(id, trackChanges);
            if (sportEntity is null)
            {
                _logger.LogError($"Sport with id: {id} doesn't exist in the database.");
                throw new SportNotFoundException($"Sport with id: {id} doesn't exist in the database.");
            }

            var sport = _mapper.Map<SportForReturnDto>(sportEntity);
            return sport;
        }
    }
}
