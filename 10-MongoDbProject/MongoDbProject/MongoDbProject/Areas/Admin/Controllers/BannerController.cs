using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.BannerDtos;
using MongoDbProject.Services.BannerServices;
using MongoDbProject.Services.ImageServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController(IBannerService _bannerService, IImageService _imageService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _bannerService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            if (createBannerDto.ImageFile != null)
            {
                try
                {
                    createBannerDto.ImageUrl = await _imageService.SaveImageAsync(createBannerDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(createBannerDto);
                }
            }
            await _bannerService.CreateAsync(createBannerDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBanner(string id)
        {
            await _bannerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBanner(string id)
        {
            var value = await _bannerService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            if (updateBannerDto.ImageFile != null)
            {
                try
                {
                    updateBannerDto.ImageUrl = await _imageService.SaveImageAsync(updateBannerDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(updateBannerDto);
                }
            }

            await _bannerService.UpdateAsync(updateBannerDto);
            return RedirectToAction("Index");
        }
    }
}
