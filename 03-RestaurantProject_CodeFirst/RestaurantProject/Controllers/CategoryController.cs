using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class CategoryController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            var categories = db.RestaurantCategories.ToList();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = db.RestaurantCategories.Find(id);
            var categoryCount = db.RestaurantCategories.Count();
            var categoryUsed = db.RestaurantProducts.Count(x => x.RestaurantCategoryId == id);

            if (categoryCount <= 1)
            {
                ModelState.AddModelError("DeleteCategory", "You cant delete all categories");
            }
            if (categoryUsed > 0)
            {
                ModelState.AddModelError("DeleteCategory", "You cant delete a category which is used");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Category");
            }

            db.RestaurantCategories.Remove(category);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Deleting process completed successfully" };

            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var category = db.RestaurantCategories.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Update(RestaurantCategory category)
        {
            var myCategory = db.RestaurantCategories.Find(category.RestaurantCategoryId);

            myCategory.CategoryName = category.CategoryName;

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Category");
            }

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Updating process completed successfully" };

            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(RestaurantCategory category)
        {
            int categoryCount = db.RestaurantCategories.Count();
            if (categoryCount >= 10)
            {
                ModelState.AddModelError("AddProduct", "You cant add more than 10 category.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Category");
            }

            db.RestaurantCategories.Add(category);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Category");
        }
    }
}