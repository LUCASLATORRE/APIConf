using AutoMapper;
using Data.DbModels;
using Entities.CustomEntities.User;

namespace API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, DtoUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<AddUser, User>();


            CreateMap<UpdateUser, User>()
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
