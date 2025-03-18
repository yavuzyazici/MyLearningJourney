using AutoMapper;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.Dtos.ServiceDtos;

namespace MongoDbProject.Mappings
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
        }
    }
}
