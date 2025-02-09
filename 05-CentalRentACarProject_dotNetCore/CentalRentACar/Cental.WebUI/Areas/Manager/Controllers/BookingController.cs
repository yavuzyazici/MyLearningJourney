using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Enums;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class BookingController(IBookingService _bookingService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _bookingService.TGetAll().OrderByDescending(x=> x.PickUpDate);
            var bookings = _mapper.Map<List<ManagerPanelBookingDto>>(data);

            return View(bookings);
        }
        [HttpGet]
        public IActionResult ChangeStatus(int bookingId)
        {
            var data = _bookingService.TGetById(bookingId);
            var booking = _mapper.Map<ApproveBookingDto>(data);

            ViewBag.Statuses = GetEnumValues.GetEnums<BookingStatus>();
            return View(booking);
        }
        [HttpPost]
        public IActionResult ChangeStatus(ApproveBookingDto model)
        {
            var booking = _bookingService.TGetById(model.BookingId);
            booking.BookingStatus = model.BookingStatus;
            _bookingService.TUpdate(booking);

            return RedirectToAction("Index");
        }
    }
}
