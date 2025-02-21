using AjaxProjectExample.Context;
using AjaxProjectExample.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjaxProjectExample.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerContext _customerContext;

        public CustomerController(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
            var values = _customerContext.Customers.ToList();
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult CreateCustomer(Customer customer)
        {
            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();
            var values = JsonConvert.SerializeObject(customer);
            return Json(values);
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = _customerContext.Customers.Find(id);
            _customerContext.Customers.Remove(value);
            _customerContext.SaveChanges();
            return NoContent();
        }

        public IActionResult GetCutomer(int id)
        {
            var value = _customerContext.Customers.Find(id);
            var jsonValues= JsonConvert.SerializeObject(value);
            return Json(jsonValues);
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerContext.Customers.Update(customer);
            _customerContext.SaveChanges();
            return NoContent();
        }
    }
}