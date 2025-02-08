using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.ViewComponents.ManagerLayout
{
    public class _ManagerLayoutNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
