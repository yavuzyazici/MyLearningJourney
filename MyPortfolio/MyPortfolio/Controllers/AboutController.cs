using MyPortfolio.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Update(MyPortfolioTblAbout about)
        {
            var myAbout = db.MyPortfolioTblAbouts.FirstOrDefault(); //Tek data bulunuyor
            myAbout.Title = about.Title;
            myAbout.Description = about.Description;
            myAbout.ImageUrl = about.ImageUrl;
            myAbout.CvUrl = about.CvUrl;
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "About");
            }
            db.SaveChanges();
            return RedirectToAction("Index", "About");
        }
    }
}