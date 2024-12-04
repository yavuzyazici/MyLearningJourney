using BasicCRUDoperations.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicCRUDoperations.Controllers
{
    public class CustomerController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        public ActionResult Index()
        {
            var data = db.BasicCRUDTblCustomers.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(BasicCRUDTblCustomer newData)
        {
            db.BasicCRUDTblCustomers.Add(newData);
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = db.BasicCRUDTblCustomers.Find(id);
            db.BasicCRUDTblCustomers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var customer = db.BasicCRUDTblCustomers.Find(id);
            return View("Update", customer);
        }
        [HttpPost]
        public ActionResult Update(BasicCRUDTblCustomer newCustomer)
        {
            var customer = db.BasicCRUDTblCustomers.Find(newCustomer.CustomerId);
            customer.CustomerName = newCustomer.CustomerName;
            customer.CustomerSurname = newCustomer.CustomerSurname;
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}