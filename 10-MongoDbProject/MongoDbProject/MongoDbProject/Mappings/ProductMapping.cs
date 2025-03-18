using AutoMapper;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.Dtos.ProductDtos;

namespace MongoDbProject.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UIProductDto>().ReverseMap();
            CreateMap<ResultProductDto, UIProductDto>().ReverseMap();
        }
    }
}
