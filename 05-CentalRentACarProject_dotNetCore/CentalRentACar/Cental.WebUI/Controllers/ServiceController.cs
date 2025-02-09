using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        [Route("service")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
