using Microsoft.Ajax.Utilities;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var user = db.TblUsers.Find(Session["UserId"]);
            return View(user);
        }
        [HttpPost]
        public ActionResult Index(TblUser userData)
        {
            var user = db.TblUsers.Find(Session["UserId"]);

            ModelState.Remove("Password");

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return RedirectToAction("Index", "Profile");
            }

            if (userData.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "wwwroot\\assets\\img\\avatars\\";
                var fileName = Path.Combine(saveLocation, userData.ImageFile.FileName);
                userData.ImageFile.SaveAs(fileName);
                userData.ProfilePictureUrl = "/wwwroot/assets/img/avatars/" + userData.ImageFile.FileName;
            }
            
            user.Name = userData.Name;
            user.UserName = userData.UserName;
            user.EMail = userData.EMail;
            user.ProfilePictureUrl = userData.ProfilePictureUrl;
            db.SaveChanges();
            return View(user);
        }
        public ActionResult RenewPassword(string password, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                ModelState.AddModelError("", "New password cannot be empty.");
            }

            var user = db.TblUsers.Find(Session["UserId"]);
            if (user.Password == password)
                user.Password = newPassword;
            else
                ModelState.AddModelError("","Your current password is incorect");

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
    }
}