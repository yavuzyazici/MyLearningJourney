using BookStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}
