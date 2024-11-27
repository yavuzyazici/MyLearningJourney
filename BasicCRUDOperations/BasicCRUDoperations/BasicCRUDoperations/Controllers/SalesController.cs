using BasicCRUDoperations.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicCRUDoperations.Controllers
{
    public class SalesController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Products = db.BasicCRUDTblProducts.ToList();
            ViewBag.Customers = db.BasicCRUDTblCustomers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(BasicCRUDTblSale sale)
        {
            db.BasicCRUDTblSales.Add(sale);
            db.SaveChanges();
            return RedirectToAction("Index", "Sales");
        }
    }
}