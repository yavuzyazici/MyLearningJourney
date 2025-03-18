using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.EventDtos;
using MongoDbProject.Services.EventServices;
using MongoDbProject.Services.ImageServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController(IEventService _eventService,IImageService _imageService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _eventService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            if (createEventDto.ImageFile != null)
            {
                try
                {
                    createEventDto.ImageUrl = await _imageService.SaveImageAsync(createEventDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(createEventDto);
                }
            }
            await _eventService.CreateAsync(createEventDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            await _eventService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEvent(string id)
        {
            var value = await _eventService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            if (updateEventDto.ImageFile != null)
            {
                try
                {
                    updateEventDto.ImageUrl = await _imageService.SaveImageAsync(updateEventDto.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(updateEventDto);
                }
            }

            await _eventService.UpdateAsync(updateEventDto);
            return RedirectToAction("Index");
        }
    }
}
