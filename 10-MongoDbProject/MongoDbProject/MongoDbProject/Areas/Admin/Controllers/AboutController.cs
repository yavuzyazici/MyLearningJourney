using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.AboutDtos;
using MongoDbProject.Services.AboutServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController(IAboutService _aboutService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAsync(createAboutDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var value = await _aboutService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAsync(updateAboutDto);
            return RedirectToAction("Index");
        }
    }
}
