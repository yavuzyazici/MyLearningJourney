using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.ViewComponents.ManagerLayout
{
    public class _ManagerLayoutHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
