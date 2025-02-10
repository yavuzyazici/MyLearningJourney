using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.DashboardDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController(IDashboardService _dashboardService, UserManager<AppUser> _userManager) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            AdminDashboardDto adminDashboardDto = new AdminDashboardDto();
            adminDashboardDto.MessageCount = _dashboardService.GetCount<Message>();
            adminDashboardDto.NonReadedMessageCount = _dashboardService.Where<Message>(x => x.IsRead == false).Count();
            adminDashboardDto.CarCount = _dashboardService.GetCount<Car>();
            adminDashboardDto.RentedCarCount = _dashboardService.Where<Booking>(x => x.BookingStatus == EntityLayer.Enums.BookingStatus.Approved).Count();
            adminDashboardDto.BrandCount = _dashboardService.GetCount<Brand>();
            adminDashboardDto.BranchCount = _dashboardService.GetCount<Branch>();
            adminDashboardDto.UserCount = _userManager.Users.Count();
            adminDashboardDto.ServiceCount = _dashboardService.GetCount<Service>();
            adminDashboardDto.PendingBookingCount = _dashboardService.Where<Booking>(x=>x.BookingStatus == EntityLayer.Enums.BookingStatus.PendingApproval).Count();
            adminDashboardDto.AverageCarRating = _dashboardService.Where<Review>(x => x.CarId >= 0).Average(x => x.Rating);
            adminDashboardDto.Total5StarReview = _dashboardService.Where<Review>(x => x.Rating == 5).Count();

            return View(adminDashboardDto);
        }
    }
}