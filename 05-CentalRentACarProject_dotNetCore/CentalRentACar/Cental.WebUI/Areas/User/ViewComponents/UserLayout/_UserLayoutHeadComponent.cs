using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.ViewComponents.UserLayout
{
    public class _UserLayoutHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
