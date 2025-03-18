using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.ContactDtos;
using MongoDbProject.Services.ContactServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController(IContactService _contactService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _contactService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateAsync(createContactDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            var value = await _contactService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateAsync(updateContactDto);
            return RedirectToAction("Index");
        }
    }
}
