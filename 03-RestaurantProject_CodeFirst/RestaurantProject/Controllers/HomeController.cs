using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HomeHead()
        {
            var meta = db.RestaurantMetas.FirstOrDefault();
            return PartialView(meta);
        }
        public PartialViewResult HomeHeader()
        {
            return PartialView();
        }
        public PartialViewResult HomeHero()
        {
            var hero = db.RestaurantHeros.FirstOrDefault();
            return PartialView(hero);
        }
        public PartialViewResult HomeAbout()
        {
            var about = db.RestaurantAbouts.FirstOrDefault();
            return PartialView(about);
        }
        public PartialViewResult HomeService()
        {
            var services = db.RestaurantServices.ToList();
            return PartialView(services);
        }
        public PartialViewResult HomeMenu()
        {
            var categories = db.RestaurantCategories.ToList();
            return PartialView(categories);
        }
        public PartialViewResult HomeTestimonial()
        {
            var testimonials = db.RestaurantTestimonials.ToList();
            return PartialView(testimonials);
        }
        public PartialViewResult HomeEvents()
        {
            var events = db.RestaurantEvents.ToList();
            return PartialView(events);
        }
        public PartialViewResult HomeChefs()
        {
            var chefs = db.RestaurantChefs.ToList();
            return PartialView(chefs);
        }
        public PartialViewResult HomeChefSocial(int chefId)
        {
            var chefSocials = db.RestaurantChefSocials.Where(x => x.RestaurantChefId == chefId).ToList();
            return PartialView(chefSocials);
        }
        [HttpGet]
        public PartialViewResult HomeBookTable()
        {
            return PartialView();
        }
        [HttpPost]
        public string HomeBookTable(RestaurantBooking booking)
        {
            if (booking.BookingDate < DateTime.Now)
            {
                return "Booking date can't be at past";
            }
            if (booking.BookingDate == DateTime.Today &&
                booking.BookingHour.Hours < DateTime.Now.Hour &&
                booking.BookingHour.Minutes < DateTime.Now.Minute)
            {
                return "Booking time can't be at past";
            }

            if (!ModelState.IsValid)
            {
                return "Some error occurred";
            }
            db.RestaurantBookings.Add(booking);
            db.SaveChanges();
            return "Booking request completed successfully. Wait till we accept";
        }
        public PartialViewResult HomeGallery()
        {
            var gallery = db.RestaurantPhotoGalleries.ToList();
            return PartialView(gallery);
        }
        [HttpGet]
        public PartialViewResult HomeContact()
        {
            var contactInfo = db.RestaurantContactInfo.FirstOrDefault();
            return PartialView(contactInfo);
        }
        [HttpPost]
        public string HomeContact(RestaurantMessage message)
        {
            if (!ModelState.IsValid)
            {
                return "An error accured";
            }
            db.RestaurantMessage.Add(message);
            db.SaveChanges();
            return "Your message has been sent successfully. Thank you!";
        }
        public PartialViewResult HomeFooter()
        {
            var contactInfo = db.RestaurantContactInfo.FirstOrDefault();
            return PartialView(contactInfo);
        }
    }
}