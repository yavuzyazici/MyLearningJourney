using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.InstructorDtos;
using MongoDbProject.Services.InstructorServices;
using System.Security.Policy;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService _instructorService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _instructorService.GetAllInstructorAsync();
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
            await _instructorService.CreateInstructorAsync(createInstructorDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteInstructor(string id)
        {
            await _instructorService.DeleteInstructorAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInstructor(string id)
        {
            var value = await _instructorService.GetInstructorByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInstructor(UpdateInstructorDto updateInstructorDto)
        {
            await _instructorService.UpdateInstructorAsync(updateInstructorDto);
            return RedirectToAction("Index");
        }
    }
}