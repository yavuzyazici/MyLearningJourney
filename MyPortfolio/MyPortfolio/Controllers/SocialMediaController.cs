using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
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