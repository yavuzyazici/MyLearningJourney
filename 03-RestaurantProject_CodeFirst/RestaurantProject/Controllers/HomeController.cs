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
    }
}