using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BranchDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Contact
{
    public class _ContactBranchListComponent(IBranchService _branchService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var data = _branchService.TGetAll();
            var branches = _mapper.Map<List<UIBranchDto>>(data);
            return View(branches);
        }
    }
}
