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
    public class AboutController : Controller
    {
        public void SaveImage(RestaurantAbout about)
        {
            if (about.AboutImage != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\abouts\\main\\";
                var fileName = Path.Combine(saveLocation, about.AboutImage.FileName.Replace(" ", "-"));
                about.AboutImage.SaveAs(fileName);
                about.ImageUrl = "/assets/images/abouts/main/" + about.AboutImage.FileName.Replace(" ", "-");
            }
            if (about.VideoImage != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\abouts\\videos\\";
                var fileName = Path.Combine(saveLocation, about.VideoImage.FileName.Replace(" ", "-"));
                about.VideoImage.SaveAs(fileName);
                about.VideoImageUrl = "/assets/images/abouts/videos/" + about.VideoImage.FileName.Replace(" ", "-");
            }
        }

        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            var about = db.RestaurantAbouts.FirstOrDefault();
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(RestaurantAbout about)
        {
            var myAbout = db.RestaurantAbouts.FirstOrDefault();

            SaveImage(about);

            myAbout.ImageUrl = about.ImageUrl;
            myAbout.Item1 = about.Item1;
            myAbout.Item2 = about.Item2;
            myAbout.Item3 = about.Item3;
            myAbout.Description = about.Description;
            myAbout.VideoUrl = about.VideoUrl;
            myAbout.Phone = about.Phone;
            myAbout.VideoImageUrl = about.VideoImageUrl;

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "About");
            }

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Update process completed successfully" };

            return RedirectToAction("Index", "About");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var about = db.RestaurantAbouts.Find(id);
            var aboutCount = db.RestaurantAbouts.Count();

            if (aboutCount <= 1)
            {
                ModelState.AddModelError("DeleteAbout", "You cant delete all Abouts");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "About");
            }

            db.RestaurantAbouts.Remove(about);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Delete process completed successfully" };

            return RedirectToAction("Index", "About");
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(RestaurantAbout about)
        {
            int aboutCount = db.RestaurantAbouts.Count();
            if (aboutCount <= 1)
            {
                ModelState.AddModelError("AddAbout", "You cant add about while you have about.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "About");
            }
            db.RestaurantAbouts.Add(about);
            SaveImage(about);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "About");
        }
    }
}