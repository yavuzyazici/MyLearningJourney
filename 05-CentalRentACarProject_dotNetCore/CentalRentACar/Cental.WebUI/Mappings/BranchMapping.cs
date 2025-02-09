using AutoMapper;
using Cental.DtoLayer.BranchDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BranchMapping : Profile
    {
        public BranchMapping()
        {
            CreateMap<Branch, UIBranchDto>().ReverseMap();
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
            CreateMap<Branch, ResultBranchDto>().ReverseMap();
        }
    }
}
