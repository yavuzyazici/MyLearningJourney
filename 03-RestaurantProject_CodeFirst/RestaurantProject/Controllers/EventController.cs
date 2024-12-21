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
    public class EventController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        public void SaveImage(RestaurantEvent @event)
        {
            if (@event.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\event\\";
                var fileName = Path.Combine(saveLocation, @event.ImageFile.FileName.Replace(" ", "-"));
                @event.ImageFile.SaveAs(fileName);
                @event.ImageUrl = "/assets/images/event/" + @event.ImageFile.FileName.Replace(" ", "-");
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            var events = db.RestaurantEvents.ToList();
            return View(events);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var @event = db.RestaurantEvents.Find(id);
            var eventCount = db.RestaurantEvents.Count();

            if (eventCount <= 1)
            {
                ModelState.AddModelError("DeleteEvent", "You cant delete all Events");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Event");
            }

            db.RestaurantEvents.Remove(@event);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Delete process completed successfully" };

            return RedirectToAction("Index", "Event");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var @event = db.RestaurantEvents.Find(id);
            return View(@event);
        }
        [HttpPost]
        public ActionResult Update(RestaurantEvent @event)
        {
            var myEvent = db.RestaurantEvents.Find(@event.RestaurantEventId);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Event");
            }

            myEvent.Title = @event.Title;
            myEvent.Description = @event.Description;
            myEvent.Price = @event.Price;
            SaveImage(@event);
            myEvent.ImageUrl = @event.ImageUrl;

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Updating process completed successfully" };

            return RedirectToAction("Index", "Event");
        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(RestaurantEvent @event)
        {
            int eventCount = db.RestaurantEvents.Count();
            if (eventCount >= 10)
            {
                ModelState.AddModelError("AddEvent", "You cant add event while you have more than 10 event.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Event");
            }
            db.RestaurantEvents.Add(@event);
            SaveImage(@event);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Event");
        }
    }
}