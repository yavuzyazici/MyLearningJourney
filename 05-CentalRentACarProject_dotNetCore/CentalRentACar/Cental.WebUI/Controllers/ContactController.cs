using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class ContactController(IMessageService _messageService) : Controller
    {
        [Route("contact")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(CreateMessageDto model)
        {
            _messageService.TCreate(model);
            return NoContent();
        }
    }
}
