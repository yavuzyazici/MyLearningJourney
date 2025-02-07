using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Enums;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.Cars
{
    public class _CarFilterCarsComponent(IBrandService _brandService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var brands = _brandService.TGetAll();

            ViewBag.Brands = (from x in brands
                            select new SelectListItem
                            {
                                Text = x.BrandName,
                                Value = x.BrandName
                            });

            ViewBag.FuelTypes = GetEnumValues.GetEnums<FuelType>();

            ViewBag.GearTypes = GetEnumValues.GetEnums<GearType>();
            return View();
        }
    }
}
