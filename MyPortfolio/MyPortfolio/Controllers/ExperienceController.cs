using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblExperiences.OrderByDescending(x => x.EndDate == null).ThenByDescending(x => x.EndDate).ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Add(MyPortfolioTblExperience experience)
        {
            db.MyPortfolioTblExperiences.Add(experience);
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Experience");
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Experience");
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblExperience experience)
        {
            var myExperience = db.MyPortfolioTblExperiences.Find(experience.ExperienceId);
            myExperience.CompanyName = experience.CompanyName;
            myExperience.Title = experience.Title;
            myExperience.StartDate = experience.StartDate;
            myExperience.EndDate = experience.EndDate;
            myExperience.Description = experience.Description;
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Experience");
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Experience");
        }
        [HttpPost]
        public ActionResult Delete(int ExperienceId)
        {
            var myExperience = db.MyPortfolioTblExperiences.Find(ExperienceId);
            db.MyPortfolioTblExperiences.Remove(myExperience);
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Experience");
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Experience");
        }
    }
}