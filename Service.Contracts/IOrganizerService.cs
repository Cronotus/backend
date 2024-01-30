
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IOrganizerService
    {
        Task<OrganizerDto> CreateOrganizer(OrganizerForCreationDto organizer);
    }
}
