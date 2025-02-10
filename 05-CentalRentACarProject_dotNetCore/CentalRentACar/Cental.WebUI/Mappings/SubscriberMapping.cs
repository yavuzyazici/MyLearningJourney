using AutoMapper;
using Cental.DtoLayer.SubscriberDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Mappings
{
    public class SubscriberMapping : Profile
    {
        public SubscriberMapping()
        {
            CreateMap<Subscriber, CreateSubscriberDto>().ReverseMap();
            CreateMap<Subscriber, ResultSubscribeDto>().ReverseMap();
        }
    }
}
