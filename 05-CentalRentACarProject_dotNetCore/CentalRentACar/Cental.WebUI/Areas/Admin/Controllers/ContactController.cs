using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ContactController(IContactService _contactService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _contactService.TGetFirst();

            var values = _mapper.Map<ResultContactDto>(data);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto model)
        {
            if (_contactService.TGetAll().Count() >= 1)
            {
                ModelState.AddModelError("", "You cant have more than 1 contact info");
                return View(model);
            }
            _contactService.TCreate(model);
            return RedirectToAction("Index", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var data = _contactService.TGetById(id);
            var contact = _mapper.Map<UpdateContactDto>(data);
            return View(contact);
        }
        [HttpPost]
        public IActionResult UpdateContact(UpdateContactDto data)
        {
            _contactService.TUpdate(data);
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
