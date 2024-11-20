using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblSocialMedias.ToList();
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(MyPortfolioTblSocialMedia socialMedia)
        {
            db.MyPortfolioTblSocialMedias.Add(socialMedia);
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "SocialMedia");
            }
            db.SaveChanges();

            return RedirectToAction("Index", "SocialMedia");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MyPortfolioTblSocialMedia socialMedia)
        {
            var mySocialMedia = db.MyPortfolioTblSocialMedias.Find(socialMedia.SocialMediaId);
            mySocialMedia.Name = socialMedia.Name;
            mySocialMedia.Url = socialMedia.Url;
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "SocialMedia");
            }

            db.SaveChanges();

            return RedirectToAction("Index", "SocialMedia");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int SocialMediaId)
        {
            var mySocialMedia = db.MyPortfolioTblSocialMedias.Find(SocialMediaId);
            db.MyPortfolioTblSocialMedias.Remove(mySocialMedia);

            db.SaveChanges();

            return RedirectToAction("Index", "SocialMedia");
        }
    }
}