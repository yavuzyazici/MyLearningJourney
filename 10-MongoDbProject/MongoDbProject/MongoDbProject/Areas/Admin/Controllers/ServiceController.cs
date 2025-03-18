using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.ServiceDtos;
using MongoDbProject.Services.ServiceServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController(IServiceService _serviceService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _serviceService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceService.CreateAsync(createServiceDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteService(string id)
        {
            await _serviceService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(string id)
        {
            var value = await _serviceService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceService.UpdateAsync(updateServiceDto);
            return RedirectToAction("Index");
        }
    }
}
