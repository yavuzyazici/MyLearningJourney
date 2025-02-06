using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;
using Cental.EntityLayer.Enums;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cental.WebUI.Controllers
{
    public class CarController(ICarService _carService, IMapper _mapper, CentalContext _context) : Controller
    {
        [Route("cars")]
        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["FilterCars"] != null)
            {
                var data = TempData["FilterCars"].ToString();
                if (data != null)
                {
                    var filterCars = JsonSerializer.Deserialize<List<UICarDto>>(data, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    });
                    return View(filterCars);
                }
            }



            var cars = _mapper.Map<List<UICarDto>>(_carService.TGetAll());
            return View(cars);
        }
        [HttpPost]
        public IActionResult FilterCars(string Car, string FuelType, string GearType, int MinYear)
        {
            if (!string.IsNullOrEmpty(Car) ||
                !string.IsNullOrEmpty(FuelType) ||
                !string.IsNullOrEmpty(GearType) ||
                MinYear !< 1900)
            {
                var values = _context.Cars.Where(x => x.Brand.BrandName + " " + x.ModelName == Car
                && x.GearType == GearType
                && x.FuelType == FuelType
                && x.Year >= MinYear).ToList();

                TempData["FilterCars"] = JsonSerializer.Serialize(_mapper.Map<List<UICarDto>>(values), new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                });
            }

            return RedirectToAction("Index");
        }
    }
}
