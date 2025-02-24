using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Models;

namespace BookStore.WebUI.Mapping
{
    public class EmailMapping : Profile
    {
        public EmailMapping()
        {
            CreateMap<Subscriber, MailRequest>()
                .ForMember(dest => dest.RecieverAddress, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
        }
    }
}
