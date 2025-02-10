using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.DtoLayer.SubscriberDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class ContactController(IContactService _contactService, IMessageService _messageService, ISubscriberService _subscriberService, IMapper _mapper) : Controller
    {
        [Route("contact")]
        [HttpGet]
        public IActionResult Index()
        {
            var data = _contactService.TGetFirst();
            var contact = _mapper.Map<UIContactDto>(data);
            return View(contact);
        }
        [HttpPost]
        public IActionResult SendMessage(CreateMessageDto model)
        {
            _messageService.TCreate(model);
            return NoContent();
        }
        [HttpPost]
        public IActionResult Subscribe(CreateSubscriberDto model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest("Email cannot be null.");
            }

            _subscriberService.TCreate(model);
            return Ok("Success");
        }
    }
}
