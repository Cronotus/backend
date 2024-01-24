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
        }
    }
}
