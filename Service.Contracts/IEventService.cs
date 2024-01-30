using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventPreviewForReturnDto>> GetAllEventsAsync(bool trackChanges);
    }
}
