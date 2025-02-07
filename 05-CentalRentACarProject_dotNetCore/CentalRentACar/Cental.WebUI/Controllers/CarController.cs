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
        public IActionResult FilterCars(string brand, string fuelType, string gearType, int minYear)
        {
            IQueryable<Car> values = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                values = values.Where(x => x.Brand.BrandName == brand);
            }
            if (!string.IsNullOrEmpty(gearType))
            {
                values = values.Where(x => x.GearType == gearType);
            }
            if (!string.IsNullOrEmpty(fuelType))
            {
                values = values.Where(x => x.FuelType == fuelType);
            }
            if (minYear >= 1900)
            {
                values = values.Where(x => x.Year >= minYear);
            }

            TempData["FilterCars"] = JsonSerializer.Serialize(_mapper.Map<List<UICarDto>>(values.ToList()), new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            return RedirectToAction("Index");
        }
    }
}
