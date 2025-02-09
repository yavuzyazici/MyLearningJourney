using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class BookingController(IBookingService _bookingService, UserManager<AppUser> _userManager, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _bookingService.GetByUserName(User.Identity.Name).OrderByDescending(x => x.PickUpDate);

            var bookings = _mapper.Map<List<UserPanelBookingDto>>(data);
            return View(bookings);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> BookCar(UIBookingDto model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                            .SelectMany(c => c.Errors)
                            .Select(c => c.ErrorMessage).ToList();

                return Json(new { success = false, message = errors });
            }
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                return Json(new { success = false, message = "First you have to sign in press Get Started" });
            }
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                model.UserId = user.Id;
                model.BookingStatus = EntityLayer.Enums.BookingStatus.PendingApproval;
                _bookingService.TCreate(model);

                return Json(new { success = true, message = "Booking completed successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Something went wrong. Try again later." });
            }
        }
    }
}
