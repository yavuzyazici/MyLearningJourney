using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class ReviewController(IBookingService _bookingService,IReviewService _reviewService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _bookingService.GetByUserName(User.Identity.Name)
                .Where(x =>
                x.IsReviewed == false &&
                x.BookingStatus == EntityLayer.Enums.BookingStatus.Approved);
            var booking = _mapper.Map<List<ResultReviewDto>>(data);
            return View(booking);
        }
        [HttpGet]
        public IActionResult ReviewCar(int id)
        {
            var data = _bookingService.TGetById(id);
            var booking = _mapper.Map<CreateReviewDto>(data);
            return View(booking);
        }
        [HttpPost]
        public IActionResult ReviewCar(CreateReviewDto model)
        {
            var booking = _bookingService.TGetById(model.BookingId);
            if (booking.IsReviewed == true)
            {
                ModelState.AddModelError("", "You cant review twice");
                return View(model);
            }
            booking.IsReviewed = true;
            _bookingService.TUpdate(booking);

            _reviewService.TCreate(model);
            return RedirectToAction("Index", new { area = "User" });
        }
    }
}
