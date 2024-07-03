using AutoMapper;

namespace Has_Real_Estate.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateHomeVM, Estate>()
                .ForMember(src => src.Cover, opt => opt.Ignore())
                .ForMember(src => src.UserId, opt => opt.Ignore());

            CreateMap<UpdateHomeVM, Estate>()
                .ForMember(src => src.Cover, opt => opt.Ignore())
                .ForMember(src => src.UserId, opt => opt.Ignore());
            CreateMap<Estate, UpdateHomeVM>()
                .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Cover));
        }
    }
}
