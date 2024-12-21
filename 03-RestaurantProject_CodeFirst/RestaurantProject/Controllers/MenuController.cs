using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class MenuController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        public void SaveImage(RestaurantProduct product)
        {
            if (product.ProductImage != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\products\\";
                var fileName = Path.Combine(saveLocation, product.ProductImage.FileName.Replace(" ", "-"));
                product.ProductImage.SaveAs(fileName);
                product.ImageUrl = "/assets/images/products/" + product.ProductImage.FileName.Replace(" ", "-");
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            var products = db.RestaurantProducts.ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.RestaurantProducts.Find(id);
            var productCount = db.RestaurantProducts.Count();
            
            if (productCount <= 1)
            {
                ModelState.AddModelError("DeleteProduct", "You cant delete all products");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Menu");
            }

            db.RestaurantProducts.Remove(product);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Deleting process completed successfully" };

            return RedirectToAction("Index", "Menu");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Categories = db.RestaurantCategories.ToList();
            var product = db.RestaurantProducts.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Update(RestaurantProduct product)
        {
            var myProduct = db.RestaurantProducts.Find(product.RestaurantProductId);

            myProduct.Name = product.Name;
            myProduct.Description = product.Description;
            myProduct.Price = product.Price;
            myProduct.RestaurantCategoryId = product.RestaurantCategoryId;
            SaveImage(product);
            myProduct.ImageUrl = product.ImageUrl;

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Menu");
            }

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Updating process completed successfully" };

            return RedirectToAction("Index", "Menu");
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = db.RestaurantCategories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(RestaurantProduct product)
        {
            int productCount = db.RestaurantProducts.Count();
            if (productCount >= 20)
            {
                ModelState.AddModelError("AddProduct", "You cant add more than 20 product.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Menu");
            }
            SaveImage(product);

            db.RestaurantProducts.Add(product);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Menu");
        }
    }
}