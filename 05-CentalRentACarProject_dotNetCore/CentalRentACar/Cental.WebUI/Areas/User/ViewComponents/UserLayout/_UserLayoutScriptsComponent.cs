using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.ViewComponents.UserLayout
{
    public class _UserLayoutScriptsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
