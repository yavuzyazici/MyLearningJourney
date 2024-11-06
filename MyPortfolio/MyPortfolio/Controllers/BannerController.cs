using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class BannerController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblBanners.FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblBanner banner)
        {
            var myBanner = db.MyPortfolioTblBanners.FirstOrDefault(); //Tek data bulunuyor

            myBanner.Title = banner.Title;
            myBanner.Description = banner.Description;
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Banner");
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Banner");
        }

    }
}