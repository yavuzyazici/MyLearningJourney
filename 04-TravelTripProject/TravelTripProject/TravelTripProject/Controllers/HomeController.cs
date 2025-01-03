using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var blogs = c.Blogs.Take(4).ToList();
            return View(blogs);
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var blogs = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return PartialView(blogs);
        }
        public PartialViewResult Partial2()
        {
            var blogs = c.Blogs.Take(10).ToList();
            return PartialView(blogs);
        }
        public PartialViewResult Partial3()
        {
            var blogs = c.Blogs.Take(6).ToList();
            return PartialView(blogs);
        }
    }
}