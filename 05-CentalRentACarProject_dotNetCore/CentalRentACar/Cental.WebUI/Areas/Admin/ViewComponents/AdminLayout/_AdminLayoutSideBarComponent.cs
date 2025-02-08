using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutSideBarComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.NameSurname = string.Join(" ", user.FirstName, user.LastName);
            ViewBag.ImageUrl = user.ImageUrl;

            return View();
        }
    }
}
