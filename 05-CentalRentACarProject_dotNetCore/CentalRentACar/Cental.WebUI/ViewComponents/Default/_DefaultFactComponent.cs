using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.DashboardDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFactComponent(IDashboardService _dashboardService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            UIDashboardDto dto = new UIDashboardDto();
            var rentedCars = _dashboardService.Where<Booking>(x => x.BookingStatus == EntityLayer.Enums.BookingStatus.Approved);

            dto.CarsRented = rentedCars.Count();

            dto.BrandCount = _dashboardService.GetCount<Brand>();

            dto.NumberOfCars = _dashboardService.GetCount<Car>();
            return View(dto);
        }
    }
}
