using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Enums;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.Cars
{
    public class _CarFilterCarsComponent(ICarService _carService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cars = _carService.TGetAll();

            ViewBag.Cars = (from x in cars
                            select new SelectListItem
                            {
                                Text = x.Brand.BrandName + " " + x.ModelName,
                                Value = x.Brand.BrandName + " " + x.ModelName
                            });

            ViewBag.FuelTypes = GetEnumValues.GetEnums<FuelType>();

            ViewBag.GearTypes = GetEnumValues.GetEnums<GearType>();
            return View();
        }
    }
}
