using AutoMapper;
using Cental.DtoLayer.ContactDtos;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
        }
    }
}
