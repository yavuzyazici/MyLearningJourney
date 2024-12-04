using BasicCRUDoperations.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicCRUDoperations.Controllers
{
    public class ProductController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        public ActionResult Index()
        {
            var data = db.BasicCRUDTblProducts.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = db.BasicCRUDTblCategories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(BasicCRUDTblProduct newData)
        {
            db.BasicCRUDTblProducts.Add(newData);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.BasicCRUDTblProducts.Find(id);
            db.BasicCRUDTblProducts.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Categories = db.BasicCRUDTblCategories.ToList();
            var product = db.BasicCRUDTblProducts.Find(id);
            return View("Update", product);
        }
        [HttpPost]
        public ActionResult Update(BasicCRUDTblProduct newProduct)
        {
            var product = db.BasicCRUDTblProducts.Find(newProduct.ProductId);
            product.ProductName = newProduct.ProductName;
            product.ProductCategory = newProduct.ProductCategory;
            product.Brand = newProduct.Brand;
            product.Price = newProduct.Price;
            product.Stock = newProduct.Stock;
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}