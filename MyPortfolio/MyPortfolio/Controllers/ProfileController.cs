using MyPortfolio.Models;
using System;
using System.Collections.Generic;
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
            if (user.Password != userData.Password)
            {
                ModelState.AddModelError("", "Password is incorrect");
                Session.Abandon();
                return RedirectToAction("Index", "Profile");
            }
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
    }
}