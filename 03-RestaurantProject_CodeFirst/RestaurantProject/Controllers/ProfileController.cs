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
    public class ProfileController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        public void SaveImage(RestaurantAdmin admin)
        {
            if (admin.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\admins\\";
                var fileName = Path.Combine(saveLocation, admin.ImageFile.FileName.Replace(" ", "-"));
                admin.ImageFile.SaveAs(fileName);
                admin.ImageUrl = "/assets/images/admins/" + admin.ImageFile.FileName.Replace(" ", "-");
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            var admin = db.RestaurantAdmins.FirstOrDefault();
            return View(admin);
        }
        [HttpPost]
        public ActionResult Index(RestaurantAdmin admin)
        {
            var user = db.RestaurantAdmins.FirstOrDefault();

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Chef");
            }

            SaveImage(admin);

            user.Email = admin.Email;
            user.UserName = admin.UserName;
            user.Password = admin.Password;
            user.ImageUrl = admin.ImageUrl;
            user.Name = admin.Name;

            db.SaveChanges();

            return View(user);
        }
        [HttpGet]
        public PartialViewResult AdminProfile()
        {
            var admin = db.RestaurantAdmins.FirstOrDefault();
            return PartialView(admin);
        }
    }
}