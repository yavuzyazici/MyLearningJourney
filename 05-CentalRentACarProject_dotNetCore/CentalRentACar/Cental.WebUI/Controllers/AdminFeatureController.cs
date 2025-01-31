using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminFeatureController(IFeatureService _featureService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _featureService.TGetAll();
            var features = _mapper.Map<List<ResultFeatureDto>>(data);
            return View(features);
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto data)
        {
            if (_featureService.TGetAll().Count() == 4)
            {
                ModelState.AddModelError("YouCantAddMore", "You cant add more than 4 feature");
                return RedirectToAction("Index");
            }
            _featureService.TCreate(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteFeature(int id)
        {
            if (_featureService.TGetAll().Count() == 1)
            {
                ModelState.AddModelError("YouCantDeleteAll", "You cant delete all features");
                return RedirectToAction("Index");
            }
            _featureService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var data = _featureService.TGetById(id);
            var feature = _mapper.Map<UpdateFeatureDto>(data);
            return View(feature);
        }
        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDto data)
        {
            _featureService.TUpdate(data);
            return RedirectToAction("Index");
        }
    }
}
