using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEventPictureService
    {
        void CreateEventPicture(EventPictureForCreationDto eventPictureForCreationDto);
        Task DeleteEventPicture(Guid eventPictureId);
        Task<EventPictureForReturnDto> GetEventPictureAsync(Guid eventPictureId);
        Task<IEnumerable<EventPictureForReturnDto>> GetAllEventPicturesAsync(Guid eventId);

    }
}
