using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        [Route("services")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
