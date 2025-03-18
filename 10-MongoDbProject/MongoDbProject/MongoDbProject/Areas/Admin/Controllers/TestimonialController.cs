using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.TestimonialDtos;
using MongoDbProject.Services.ImageServices;
using MongoDbProject.Services.TestimonialServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(ITestimonialService _testimonialService, IImageService _imageService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (createTestimonialDto.ImageFile != null)
            {
                try
                {
                    createTestimonialDto.ImageUrl = await _imageService.SaveImageAsync(createTestimonialDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(createTestimonialDto);
                }
            }
            await _testimonialService.CreateAsync(createTestimonialDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            if (updateTestimonialDto.ImageFile != null)
            {
                try
                {
                    updateTestimonialDto.ImageUrl = await _imageService.SaveImageAsync(updateTestimonialDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(updateTestimonialDto);
                }
            }

            await _testimonialService.UpdateAsync(updateTestimonialDto);
            return RedirectToAction("Index");
        }
    }
}
