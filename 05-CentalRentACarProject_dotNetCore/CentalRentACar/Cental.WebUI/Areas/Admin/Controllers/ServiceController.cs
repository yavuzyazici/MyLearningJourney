using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController(IServiceService _serviceService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _serviceService.TGetAll();
            var services = _mapper.Map<List<ResultServiceDto>>(data);
            return View(services);
        }
        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDto model)
        {
            _serviceService.TCreate(model);
            return RedirectToAction("Index", new {area = "Admin"});
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var data = _serviceService.TGetById(id);
            var service = _mapper.Map<UpdateServiceDto>(data);
            return View(service);
        }
        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto model)
        {
            _serviceService.TUpdate(model);
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
