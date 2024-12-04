using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblAbouts.FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblAbout aboutData)
        {
            var about = db.MyPortfolioTblAbouts.FirstOrDefault(); //Tek data bulunuyor
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return RedirectToAction("Index", "About");
            }
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (aboutData.AboutImage != null)
            {
                var saveLocation = currentDirectory + "wwwroot\\assets\\img\\about\\images\\";
                var fileName = Path.Combine(saveLocation, aboutData.AboutImage.FileName);
                aboutData.AboutImage.SaveAs(fileName);
                aboutData.ImageUrl = "/wwwroot/assets/img/about/images/" + aboutData.AboutImage.FileName;
            }
            if (aboutData.AboutCV != null)
            {
                var saveLocation = currentDirectory + "wwwroot\\assets\\img\\about\\cv\\";
                var fileName = Path.Combine(saveLocation, aboutData.AboutCV.FileName);
                aboutData.AboutCV.SaveAs(fileName);
                aboutData.CvUrl = "/wwwroot/assets/img/about/cv/" + aboutData.AboutCV.FileName;
            }

            about.Title = aboutData.Title;
            about.Description = aboutData.Description;
            about.ImageUrl = aboutData.ImageUrl;
            about.CvUrl = aboutData.CvUrl;

            db.SaveChanges();
            return RedirectToAction("Index", "About");
        }
    }
}