using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExpertiseController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblExpertises.FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblExpertise expertise)
        {
            var myExpertise = db.MyPortfolioTblExpertises.FirstOrDefault();
            myExpertise.Title = expertise.Title;
            myExpertise.Description = expertise.Description;
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Expertise");
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Expertise");
        }
    }
}