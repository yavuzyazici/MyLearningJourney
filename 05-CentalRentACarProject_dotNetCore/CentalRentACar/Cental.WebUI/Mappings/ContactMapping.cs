using AutoMapper;
using Cental.DtoLayer.ContactDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
             CreateMap<Contact, ResultContactDto>().ReverseMap();
             CreateMap<Contact, CreateContactDto>().ReverseMap();
             CreateMap<Contact, UpdateContactDto>().ReverseMap();
             CreateMap<Contact, UIContactDto>().ReverseMap();
        }
    }
}
