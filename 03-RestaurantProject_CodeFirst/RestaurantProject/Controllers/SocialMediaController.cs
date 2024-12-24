using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class SocialMediaController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            var socialMedias = db.RestaurantSocialMedias.ToList();
            return View(socialMedias);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var socialMedia = db.RestaurantSocialMedias.Find(id);
            var socialMediaCount = db.RestaurantSocialMedias.Count();
            db.RestaurantSocialMedias.Remove(socialMedia);

            if (socialMediaCount == 0)
            {
                ModelState.AddModelError("", "You cant delete all social medias");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "SocialMedia");
            }

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Delete process completed successfully" };

            return RedirectToAction("Index", "SocialMedia");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var socialMedia = db.RestaurantSocialMedias.Find(id);
            return View(socialMedia);
        }
        [HttpPost]
        public ActionResult Update(RestaurantSocialMedia socialMedia)
        {
            var mySocialMedia = db.RestaurantSocialMedias.Find(socialMedia.RestaurantSocialMediaId);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "SocialMedia");
            }

            mySocialMedia.Url = socialMedia.Url;
            mySocialMedia.Icon = socialMedia.Icon;
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Update process completed successfully" };

            return RedirectToAction("Index", "SocialMedia");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(RestaurantSocialMedia socialMedia)
        {
            db.RestaurantSocialMedias.Add(socialMedia);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "SocialMedia");
            }

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "SocialMedia");
        }
    }
}