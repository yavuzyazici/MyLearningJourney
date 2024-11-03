using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblCategories.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Add(MyPortfolioTblCategory category)
        {
            db.MyPortfolioTblCategories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int CategoryId)
        {
            var c = db.MyPortfolioTblCategories.Find(CategoryId);
            if (c != null)
            {
                db.MyPortfolioTblCategories.Remove(c);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Category");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MyPortfolioTblCategory category)
        {
            var c = db.MyPortfolioTblCategories.Find(category.CategoryId);
            c.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}