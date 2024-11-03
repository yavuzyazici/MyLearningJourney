using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblEducations.OrderByDescending(x => x.EndDate == null).ThenByDescending(x => x.EndDate).ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Add(MyPortfolioTblEducation education)
        {
            db.MyPortfolioTblEducations.Add(education);
            db.SaveChanges();
            return RedirectToAction("Index", "Education");
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblEducation education)
        {
            var myEducation = db.MyPortfolioTblEducations.Find(education.EducationId);
            myEducation.SchoolName = education.SchoolName;
            myEducation.Department = education.Department;
            myEducation.StartDate = education.StartDate;
            myEducation.EndDate = education.EndDate;
            myEducation.Description = education.Description;
            db.SaveChanges();
            return RedirectToAction("Index", "Education");
        }
        [HttpPost]
        public ActionResult Delete(int deleteEducationId)
        {
            var myEducation = db.MyPortfolioTblEducations.Find(deleteEducationId);
            db.MyPortfolioTblEducations.Remove(myEducation);
            db.SaveChanges();
            return RedirectToAction("Index", "Education");
        }
    }
}