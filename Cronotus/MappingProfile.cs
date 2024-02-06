using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Cronotus
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<ProfileForUpdateDto, User>();
            CreateMap<ProfileForUpdateDto, User>().ReverseMap();
            CreateMap<EventPreviewForReturnDto, Event>();
            CreateMap<EventForReturnDto, Event>();
            CreateMap<OrganizerForCreationDto, Organizer>();
            CreateMap<OrganizerForCreationDto, Organizer>().ReverseMap();
            CreateMap<OrganizerDto,  Organizer>().ReverseMap();
            CreateMap<OrganizerDto, Organizer>();
            CreateMap<EventForUpdateDto, Event>();
            CreateMap<EventForUpdateDto, Event>().ReverseMap();
            CreateMap<SportForReturnDto, Sport>();
            CreateMap<SportForReturnDto, Sport>().ReverseMap();
        }
    }
}
