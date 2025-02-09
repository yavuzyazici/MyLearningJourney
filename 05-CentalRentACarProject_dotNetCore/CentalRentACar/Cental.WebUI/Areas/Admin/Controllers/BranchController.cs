using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BranchDtos;
using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BranchController(IBranchService _branchService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _branchService.TGetAll();
            var branchs = _mapper.Map<List<ResultBranchDto>>(data);
            return View(branchs);
        }
        [HttpGet]
        public IActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBranch(CreateBranchDto model)
        {
            _branchService.TCreate(model);
            return RedirectToAction("Index", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateBranch(int id)
        {
            var data = _branchService.TGetById(id);
            var contact = _mapper.Map<UpdateBranchDto>(data);
            return View(contact);
        }
        [HttpPost]
        public IActionResult UpdateBranch(UpdateBranchDto data)
        {
            _branchService.TUpdate(data);
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
