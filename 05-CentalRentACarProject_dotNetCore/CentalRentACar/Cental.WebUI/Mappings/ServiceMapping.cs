﻿using AutoMapper;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, UIServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
        }
    }
}
