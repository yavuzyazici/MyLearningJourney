using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.ViewComponents.ManagerLayout
{
    public class _ManagerLayoutScriptsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
