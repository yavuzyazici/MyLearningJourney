using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class ServicesController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            var services = db.RestaurantServices.ToList();
            return View(services);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var about = db.RestaurantServices.Find(id);
            var aboutCount = db.RestaurantServices.Count();

            if (aboutCount <= 1)
            {
                ModelState.AddModelError("DeleteService", "You cant delete all Services");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Services");
            }

            db.RestaurantServices.Remove(about);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Service process completed successfully" };

            return RedirectToAction("Index", "Services");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var service = db.RestaurantServices.Find(id);
            return View(service);
        }
        [HttpPost]
        public ActionResult Update(RestaurantService service)
        {
            var myService = db.RestaurantServices.Find(service.RestaurantServiceId);

            myService.Title = service.Title;
            myService.Description = service.Description;
            myService.Icon = service.Icon;

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Services");
            }

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Updating process completed successfully" };

            return RedirectToAction("Index", "Services");
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(RestaurantService service)
        {
            int serviceCount = db.RestaurantServices.Count();
            if (serviceCount >= 3)
            {
                ModelState.AddModelError("AddService", "You cant add more than 3 service.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Services");
            }
            db.RestaurantServices.Add(service);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Services");
        }
    }
}