using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.SubscriberDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class SubscribeController(ISubscriberService _subscriberService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _subscriberService.TGetAll();
            var subscribers = _mapper.Map<List<ResultSubscribeDto>>(data);
            return View(subscribers);
        }
        [HttpGet]
        public IActionResult DeleteSubscriber(int id)
        {
            _subscriberService.TDelete(id);
            return RedirectToAction("Index", new { area = "Manager" });
        }
    }
}
