using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
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
        public ActionResult Update(MyPortfolioTblExpertis expertise)
        {
            var myExpertise = db.MyPortfolioTblExpertises.FirstOrDefault();
            myExpertise.Title = expertise.Title;
            myExpertise.Description = expertise.Description;
            db.SaveChanges();

            return RedirectToAction("Index", "Expertise");
        }
    }
}