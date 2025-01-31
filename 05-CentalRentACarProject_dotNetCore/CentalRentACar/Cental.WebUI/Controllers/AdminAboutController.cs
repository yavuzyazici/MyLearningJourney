using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
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
            _aboutService.TCreate(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteAbout(int id)
        {
            if (_aboutService.TGetAll().Count() == 1)
            {
                ModelState.AddModelError("YouCantDeleteAll", "You cant delete all abouts");
                return RedirectToAction("Index");
            }
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
            _aboutService.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}
