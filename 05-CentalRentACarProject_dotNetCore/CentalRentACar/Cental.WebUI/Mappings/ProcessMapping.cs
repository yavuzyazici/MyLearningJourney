using AutoMapper;
using Cental.DtoLayer.ProcessDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Mappings
{
    public class ProcessMapping : Profile
    {
        public ProcessMapping()
        {
            CreateMap<Process, UIProcessDtos>().ReverseMap();
            CreateMap<Process, CreateProcessDtos>().ReverseMap();
            CreateMap<Process, UpdateProcessDtos>().ReverseMap();
            CreateMap<Process, ResultProcessDtos>().ReverseMap();
        }
    }
}
