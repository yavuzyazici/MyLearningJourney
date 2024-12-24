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
    public class ChefController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        public void SaveImage(RestaurantChef chef)
        {
            if (chef.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\chef\\";
                var fileName = Path.Combine(saveLocation, chef.ImageFile.FileName.Replace(" ", "-"));
                chef.ImageFile.SaveAs(fileName);
                chef.ImageUrl = "/assets/images/chef/" + chef.ImageFile.FileName.Replace(" ", "-");
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            var chefs = db.RestaurantChefs.ToList();
            return View(chefs);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var chef = db.RestaurantChefs.Find(id);
            var chefCount = db.RestaurantChefs.Count();

            if (chefCount <= 1)
            {
                ModelState.AddModelError("DeleteChef", "You cant delete all chefs");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Chef");
            }

            db.RestaurantChefs.Remove(chef);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Delete process completed successfully" };

            return RedirectToAction("Index", "Chef");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var chef = db.RestaurantChefs.Find(id);
            return View(chef);
        }
        [HttpPost]
        public ActionResult Update(RestaurantChef chef)
        {
            var myChef = db.RestaurantChefs.Find(chef.RestaurantChefId);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Chef");
            }

            myChef.NameSurname = chef.NameSurname;
            myChef.Title = chef.Title;
            myChef.Description = chef.Description;
            SaveImage(chef);
            myChef.ImageUrl = chef.ImageUrl;

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Updating process completed successfully" };

            return RedirectToAction("Index", "Chef");
        }
        [HttpGet]
        public ActionResult AddChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddChef(RestaurantChef chef)
        {
            int chefCount = db.RestaurantChefs.Count();
            if (chefCount >= 3)
            {
                ModelState.AddModelError("AddChef", "You cant add chef while you have more than 3 chef.");
            }
            
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Chef");
            }
            db.RestaurantChefs.Add(chef);
            SaveImage(chef);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Chef");
        }
        [HttpGet]
        public ActionResult DeleteSocial(int id)
        {
            var socialMedia = db.RestaurantChefSocials.Find(id);
            db.RestaurantChefSocials.Remove(socialMedia);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Chef");
            }

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Delete process completed successfully" };

            return RedirectToAction("Index", "Chef");
        }
        [HttpGet]
        public ActionResult UpdateSocial(int id)
        {
            var socialMedia = db.RestaurantChefSocials.Find(id);
            return View(socialMedia);
        }
        [HttpPost]
        public ActionResult UpdateSocial(RestaurantChefSocial chefSocial)
        {
            var mySocial = db.RestaurantChefSocials.Find(chefSocial.RestaurantChefSocialId);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Chef");
            }

            mySocial.Name = chefSocial.Name;
            mySocial.Url = chefSocial.Url;
            mySocial.Icon = chefSocial.Icon;
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Update process completed successfully" };

            return RedirectToAction("Index", "Chef");
        }
        [HttpGet]
        public ActionResult AddChefSocial(int id)
        {
            ViewBag.ChefId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddChefSocial(RestaurantChefSocial chefSocial)
        {
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Chef");
            }

            db.RestaurantChefSocials.Add(chefSocial);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Chef");
        }
    }
}