using AutoMapper;
using RESTful.API.Entities;
using RESTful.API.Models;

namespace RESTful.API.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(
                    dest => dest.CompanyName,
                    opt => opt.MapFrom(src => src.Name)
                );

            CreateMap<CompanyAddDto, Company>();
        }
    }
}
