using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class AboutController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var about = context.Abouts.FirstOrDefault();
            return View(about);
        }
    }
}