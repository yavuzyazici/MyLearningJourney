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
    public class GalleryController : Controller
    {
        public void SaveImage(RestaurantPhotoGallery photo)
        {
            if (photo.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\photo\\";
                var fileName = Path.Combine(saveLocation, photo.ImageFile.FileName.Replace(" ", "-"));
                photo.ImageFile.SaveAs(fileName);
                photo.ImageUrl = "/assets/images/photo/" + photo.ImageFile.FileName.Replace(" ", "-");
            }
        }
        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            var photos = db.RestaurantPhotoGalleries.ToList();
            return View(photos);
        }
        [HttpPost]
        public ActionResult AddPhoto(RestaurantPhotoGallery photo)
        {
            int photoCount = db.RestaurantPhotoGalleries.Count();
            if (photoCount >= 20)
            {
                ModelState.AddModelError("AddPhoto", "You cant add event while you have more than 20 photo.");
            }

            SaveImage(photo);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Gallery");
            }

            db.RestaurantPhotoGalleries.Add(photo);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Gallery");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var photo = db.RestaurantPhotoGalleries.Find(id);
            var photoCount = db.RestaurantPhotoGalleries.Count();

            if (photoCount <= 1)
            {
                ModelState.AddModelError("DeleteGallery", "You cant delete all photos");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Gallery");
            }

            db.RestaurantPhotoGalleries.Remove(photo);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Delete process completed successfully" };

            return RedirectToAction("Index", "Gallery");
        }
    }
}