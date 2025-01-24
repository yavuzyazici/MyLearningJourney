using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminAboutController(IAboutService _aboutService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var data = _aboutService.TGetAll();

            var values = _mapper.Map<List<ResultAboutDto>>(data); 
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto model)
        {
            var about = _mapper.Map<About>(model);

            _aboutService.TCreate(about);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var model = _aboutService.TGetById(id);

            var about = _mapper.Map<UpdateAboutDto>(model);
            return View(about);
        }
        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto model)
        {
            var about = _mapper.Map<About>(model);
            _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
