using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            var admin = db.RestaurantAdmins.Find(Session["UserId"]);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Index(RestaurantAdmin admin)
        {
            var user = db.RestaurantAdmins.Find(Session["UserId"]);

            ModelState.Remove("Password");

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Profile");
            }

            SaveImage(admin);

            user.Email = admin.Email;
            user.UserName = admin.UserName;
            user.ImageUrl = admin.ImageUrl;
            user.Name = admin.Name;

            db.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }
        [HttpPost]
        public ActionResult RenewPassword(string password, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                ModelState.AddModelError("", "New password cannot be empty.");
            }

            var user = db.RestaurantAdmins.Find(Session["UserId"]);
            if (user.Password == password)
                user.Password = newPassword;
            else
                ModelState.AddModelError("", "Your current password is incorect");

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return RedirectToAction("Index", "Profile");
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0}, Error: {1}",
                            validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw; // Hata tekrar fırlatılır
            }
            return RedirectToAction("Index", "Profile");
        }
        [HttpGet]
        public PartialViewResult AdminProfile()
        {
            var admin = db.RestaurantAdmins.FirstOrDefault();
            return PartialView(admin);
        }
    }
}