using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.AdminLayout
{
    public class _ManagerLayoutSideBarComponent() : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
