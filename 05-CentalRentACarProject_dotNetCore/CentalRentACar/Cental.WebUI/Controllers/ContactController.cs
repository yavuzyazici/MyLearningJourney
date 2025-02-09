using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class ContactController(IContactService _contactService,IMessageService _messageService, IMapper _mapper) : Controller
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
    }
}
