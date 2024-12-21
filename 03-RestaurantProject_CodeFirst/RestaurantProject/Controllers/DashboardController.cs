using RestaurantProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class DashboardController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ProductCount = db.RestaurantProducts.Count();
            ViewBag.CheapestProduct = db.RestaurantProducts.OrderBy(x => x.Price).FirstOrDefault().Price;
            ViewBag.AveragePrice = db.RestaurantProducts.Average(x => x.Price).ToString("00.00");
            ViewBag.UnReadMessages = db.RestaurantMessage.Where(x => x.IsRead == false).Count();

            ViewBag.Messages = db.RestaurantMessage.Where(x => x.IsRead == false).ToList();
            ViewBag.Booking = db.RestaurantBookings.Where(x => x.IsApproved == false).Take(50).ToList();
            return View();
        }
    }
}