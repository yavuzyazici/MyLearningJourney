using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        [HttpGet]
        public IActionResult NotFound404()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
