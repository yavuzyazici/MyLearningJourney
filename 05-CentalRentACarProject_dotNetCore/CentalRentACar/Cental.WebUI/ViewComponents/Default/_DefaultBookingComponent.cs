using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultBookingComponent(ICarService _carService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cars = _carService.TGetAll();
            ViewBag.Cars = (from x in cars
                            select new SelectListItem
                            {
                                Text = x.Brand.BrandName + ' ' + x.ModelName,
                                Value = x.CarId.ToString()
                            });
            return View();
        }
    }
}
