using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTeamComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            var dto = managers.TakeLast(4).Adapt<List<ResultUserDto>>();
            return View(dto);
        }
    }
}
