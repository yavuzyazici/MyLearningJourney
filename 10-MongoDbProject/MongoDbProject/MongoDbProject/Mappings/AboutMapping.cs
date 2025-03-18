using AutoMapper;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.Dtos.AboutDtos;

namespace MongoDbProject.Mappings
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
        }
    }
}
