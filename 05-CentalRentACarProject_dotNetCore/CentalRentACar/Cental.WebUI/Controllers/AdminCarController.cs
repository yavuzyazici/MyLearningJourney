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
using PagedList.Core;
using System.Transactions;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCarController(ICarService _carservice, IBrandService _brandService, IMapper _mapper, IImageService _imageService) : Controller
    {
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var cars = _carservice.TGetAll();
            var dtoCars = _mapper.Map<List<ResultCarDto>>(cars).AsQueryable();
            var values = new PagedList<ResultCarDto>(dtoCars, page, 3);
            return View(values);
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
        public async Task<IActionResult> CreateCar(CreateCarDto model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCar", model);
            }
            if (model.ImageFile != null)
            {
                try
                {
                    model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(model);
                }
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
        public async Task<IActionResult> UpdateCar(UpdateCarDto model)
        {
            if (model.ImageFile != null)
            {
                try
                {
                    model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(model);
                }
            }
            _carservice.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}
