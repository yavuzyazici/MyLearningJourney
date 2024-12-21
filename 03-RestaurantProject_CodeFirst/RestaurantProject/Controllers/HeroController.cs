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
    public class HeroController : Controller
    {
        RestaurantContext db = new RestaurantContext();

        public void SaveImage(RestaurantHero hero)
        {
            if (hero.HeroImage != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\heros\\";
                var fileName = Path.Combine(saveLocation, hero.HeroImage.FileName.Replace(" ", "-"));
                hero.HeroImage.SaveAs(fileName);
                hero.ImageUrl = "/assets/images/heros/" + hero.HeroImage.FileName.Replace(" ", "-");
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            var hero = db.RestaurantHeros.FirstOrDefault();
            return View(hero);
        }
        [HttpPost]
        public ActionResult Index(RestaurantHero hero)
        {
            var myHero = db.RestaurantHeros.FirstOrDefault();

            SaveImage(hero);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Hero");
            }

            myHero.Title = hero.Title;
            myHero.Description = hero.Description;
            myHero.ImageUrl = hero.ImageUrl;
            myHero.VideoUrl = hero.VideoUrl;
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Update process completed successfully" };

            return View(hero);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var hero = db.RestaurantHeros.Find(id);
            var heroCount = db.RestaurantHeros.Count();

            if (heroCount <= 1)
            {
                ModelState.AddModelError("DeleteHero", "You cant delete all Heros");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Hero");
            }

            db.RestaurantHeros.Remove(hero);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Deleting process completed successfully" };

            return RedirectToAction("Index", "Hero");
        }
        [HttpGet]
        public ActionResult AddHero()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHero(RestaurantHero hero)
        {
            int heroCount = db.RestaurantHeros.Count();
            if (heroCount <= 1)
            {
                ModelState.AddModelError("AddHero", "You cant add hero while you have hero.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Hero");
            }
            db.RestaurantHeros.Add(hero);
            SaveImage(hero);

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            db.SaveChanges();
            return RedirectToAction("Index", "Hero");
        }
    }
}