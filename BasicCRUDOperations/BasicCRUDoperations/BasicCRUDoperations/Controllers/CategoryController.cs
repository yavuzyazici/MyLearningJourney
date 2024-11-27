using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicCRUDoperations.Models.Entity;

namespace BasicCRUDoperations.Controllers
{
    public class CategoryController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        public ActionResult Index()
        {
            var data = db.BasicCRUDTblCategories.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(BasicCRUDTblCategory newData)
        {
            db.BasicCRUDTblCategories.Add(newData);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Delete(int id)
        {
            var category = db.BasicCRUDTblCategories.Find(id);
            db.BasicCRUDTblCategories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var category = db.BasicCRUDTblCategories.Find(id);
            return View("Update", category);
        }
        [HttpPost]
        public ActionResult Update(BasicCRUDTblCategory newCategory)
        {
            var category = db.BasicCRUDTblCategories.Find(newCategory.CategoryId);
            category.CategoryName = newCategory.CategoryName;
            db.SaveChanges();

            return RedirectToAction("Index", "Category");
        }
    }
}