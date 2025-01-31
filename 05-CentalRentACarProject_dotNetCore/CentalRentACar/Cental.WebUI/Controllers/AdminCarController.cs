using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Extensions;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;
using Cental.EntityLayer.Enums;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Transactions;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCarController(ICarService _carservice, IBrandService _brandService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var values = _carservice.TGetAll();
            var cars = _mapper.Map<List<ResultCarDto>>(values);
            return View(cars);
        }
        [HttpGet]
        public IActionResult CreateCar()
        {
            var brands = _brandService.TGetAll();

            ViewBag.Brands = brands.Select(x => new SelectListItem
            {
                Text = x.BrandName,
                Value = x.BrandId.ToString(),
            }).ToList();

            ViewBag.GearTypes = GetEnumValues.GetEnums<GearType>();

            ViewBag.FuelTypes = GetEnumValues.GetEnums<FuelType>();

            ViewBag.Transmissions = GetEnumValues.GetEnums<Transmission>();

            return View();
        }
        [HttpPost]
        public IActionResult CreateCar(CreateCarDto model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateCar",model);
            }
            _carservice.TCreate(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteCar(int id)
        {
            if (_carservice.TGetAll().Count() == 1)
            {
                ModelState.AddModelError("YouCantDeleteAll", "You cant delete all cars");
                return RedirectToAction("Index");
            }
            _carservice.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            var value = _carservice.TGetById(id);
            var car = _mapper.Map<UpdateCarDto>(value);

            var brands = _brandService.TGetAll();

            ViewBag.Brands = brands.Select(x => new SelectListItem
            {
                Text = x.BrandName,
                Value = x.BrandId.ToString(),
            }).ToList();

            ViewBag.GearTypes = GetEnumValues.GetEnums<GearType>();

            ViewBag.FuelTypes = GetEnumValues.GetEnums<FuelType>();

            ViewBag.Transmissions = GetEnumValues.GetEnums<Transmission>();

            return View(car);
        }
        [HttpPost]
        public IActionResult UpdateCar(UpdateCarDto model)
        {
            _carservice.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}
