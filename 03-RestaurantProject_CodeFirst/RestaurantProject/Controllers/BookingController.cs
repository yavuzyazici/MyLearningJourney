using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class BookingController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            var bookings = db.RestaurantBookings.OrderByDescending(x => x.IsApproved == false).ToList();
            return View(bookings);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var booking = db.RestaurantBookings.Find(id);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Booking");
            }

            db.RestaurantBookings.Remove(booking);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Deleting process completed successfully" };

            return RedirectToAction("Index", "Booking");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var booking = db.RestaurantBookings.Find(id);
            return View(booking);
        }
        [HttpPost]
        public ActionResult Update(RestaurantBooking booking)
        {
            var myBooking = db.RestaurantBookings.Find(booking.RestaurantBookingId);

            if (booking.BookingDate < DateTime.Now)
            {
                ModelState.AddModelError("BookingDate", "Booking date can't be at past");
            }
            if (booking.BookingDate == DateTime.Today &&
                booking.BookingHour.Hours < DateTime.Now.Hour &&
                booking.BookingHour.Minutes < DateTime.Now.Minute)
            {
                ModelState.AddModelError("BookingTime", "Booking time can't be at past");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Booking");
            }

            myBooking.Name = booking.Name;
            myBooking.Email = booking.Email;
            myBooking.Phone = booking.Phone;
            myBooking.BookingDate = booking.BookingDate;
            myBooking.PersonCount = booking.PersonCount;
            myBooking.MessageContent = booking.MessageContent;
            myBooking.IsApproved = booking.IsApproved;
            myBooking.BookingHour = booking.BookingHour;


            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Booking process completed successfully" };

            return RedirectToAction("Index", "Booking");
        }
        [HttpGet]
        public ActionResult AddBooking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBooking(RestaurantBooking booking)
        {
            if (booking.BookingDate < DateTime.Now)
            {
                ModelState.AddModelError("BookingDate", "Booking date can't be at past");
            }
            if (booking.BookingDate == DateTime.Today &&
                booking.BookingHour.Hours < DateTime.Now.Hour &&
                booking.BookingHour.Minutes < DateTime.Now.Minute)
            {
                ModelState.AddModelError("BookingTime", "Booking time can't be at past");
            }
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Booking");
            }
            
            db.RestaurantBookings.Add(booking);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Booking");
        }
    }
}