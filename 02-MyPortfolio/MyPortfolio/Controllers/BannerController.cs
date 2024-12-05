using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class BannerController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblBanners.OrderByDescending(x => x.IsShown == true).ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Add(MyPortfolioTblBanner banner)
        {
            if (banner.IsShown == true)
            {
                MyPortfolioTblBanner mainBanner = db.MyPortfolioTblBanners.Where(x => x.IsShown == true).FirstOrDefault();
                mainBanner.IsShown = false;
            }
            db.MyPortfolioTblBanners.Add(banner);
            db.SaveChanges();
            return RedirectToAction("Index", "Banner");
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblBanner banner)
        {
            if (banner.IsShown == true)
            {
                MyPortfolioTblBanner mainBanner = db.MyPortfolioTblBanners.Where(x => x.IsShown == true).FirstOrDefault();
                mainBanner.IsShown = false;
            }

            var myBanner = db.MyPortfolioTblBanners.Find(banner.BannerId);

            myBanner.Title = banner.Title;
            myBanner.Description = banner.Description;
            myBanner.IsShown = banner.IsShown;
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Banner");
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Banner");
        }
        [HttpPost]
        public ActionResult Delete(int BannerId)
        {
            var banner = db.MyPortfolioTblBanners.Find(BannerId);
            if (banner.IsShown == true)
            {
                ModelState.AddModelError("", "You can't delete main banner. First change the main banner");
            }
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Banner");
            }
            db.MyPortfolioTblBanners.Remove(banner);
            db.SaveChanges();
            return RedirectToAction("Index", "Banner");
        }
    }
}