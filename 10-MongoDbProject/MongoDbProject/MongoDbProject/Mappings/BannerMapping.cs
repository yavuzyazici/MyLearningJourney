using AutoMapper;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.Dtos.BannerDtos;

namespace MongoDbProject.Mappings
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<ResultBannerDto, Banner>().ReverseMap();
            CreateMap<CreateBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();
        }
    }
}
