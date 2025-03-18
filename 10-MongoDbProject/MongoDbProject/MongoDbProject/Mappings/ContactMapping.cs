using AutoMapper;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.Dtos.ContactDtos;

namespace MongoDbProject.Mappings
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
        }
    }
}
