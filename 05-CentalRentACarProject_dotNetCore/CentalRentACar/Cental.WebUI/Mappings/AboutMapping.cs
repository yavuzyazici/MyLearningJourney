using AutoMapper;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            var thisYear = DateTime.Now.Year;
            CreateMap<About, UIAboutDto>().ForMember(dst => dst.YearsOfExperience, opt => opt.MapFrom(src => thisYear - src.StartYear)).ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
        }
    }
}
