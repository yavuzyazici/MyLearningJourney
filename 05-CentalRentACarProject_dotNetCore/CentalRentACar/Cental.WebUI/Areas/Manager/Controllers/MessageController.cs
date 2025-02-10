using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class MessageController(IMessageService _messageService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _messageService.TGetAll().OrderBy(x=> x.IsRead == false);
            var messages = _mapper.Map<List<ResultMessageDto>>(data);
            return View(messages);
        }
        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            var message = _messageService.TGetById(id);
            message.IsRead = !message.IsRead;
            _messageService.TUpdate(message);
            return RedirectToAction("Index", new { area = "Manager" });
        }
        [HttpGet]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("Index", new { area = "Manager" });
        }
    }
}
