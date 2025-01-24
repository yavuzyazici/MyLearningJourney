using AutoMapper;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BrandMappings : Profile
    {
        public BrandMappings()
        {
            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
        }
    }
}
