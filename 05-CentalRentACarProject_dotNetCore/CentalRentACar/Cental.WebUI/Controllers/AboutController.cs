using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        [Route("about")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
