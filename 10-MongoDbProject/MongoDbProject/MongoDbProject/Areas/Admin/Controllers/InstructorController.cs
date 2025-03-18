using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.InstructorDtos;
using MongoDbProject.Services.ImageServices;
using MongoDbProject.Services.InstructorServices;
using System.Security.Policy;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService _instructorService,IImageService _imageService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _instructorService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateInstructor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateInstructor(CreateInstructorDto createInstructorDto)
        {
            if (createInstructorDto.ImageFile != null)
            {
                try
                {
                    createInstructorDto.ImageUrl = await _imageService.SaveImageAsync(createInstructorDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(createInstructorDto);
                }
            }
            await _instructorService.CreateAsync(createInstructorDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteInstructor(string id)
        {
            await _instructorService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInstructor(string id)
        {
            var value = await _instructorService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInstructor(UpdateInstructorDto updateInstructorDto)
        {
            if (updateInstructorDto.ImageFile != null)
            {
                try
                {
                    updateInstructorDto.ImageUrl = await _imageService.SaveImageAsync(updateInstructorDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(updateInstructorDto);
                }
            }

            await _instructorService.UpdateAsync(updateInstructorDto);
            return RedirectToAction("Index");
        }
    }
}