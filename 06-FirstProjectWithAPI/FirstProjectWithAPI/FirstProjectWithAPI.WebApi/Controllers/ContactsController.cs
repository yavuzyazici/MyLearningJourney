using FirstProjectWithAPI.WebApi.Context;
using FirstProjectWithAPI.WebApi.Dtos.ContactDtos;
using FirstProjectWithAPI.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.MapLocation = createContactDto.MapLocation;
            contact.Address = createContactDto.Address;
            contact.Phone = createContactDto.Phone;
            contact.OpenHours = createContactDto.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Contact created succesfully");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return Ok("Contact deleted succesfully");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.ContactId = updateContactDto.ContactId;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.OpenHours = updateContactDto.OpenHours;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Contact updated succesfully");
        }
    }
}
