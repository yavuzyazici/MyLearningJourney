using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminRoleAssignController(UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            List<ResultUserDto> resultUserDtoList = new List<ResultUserDto>();
            foreach (var user in users)
            {
                var dto = new ResultUserDto();
                var userRoles = await _userManager.GetRolesAsync(user);

                dto.Roles = userRoles;
                dto.Id = user.Id;
                dto.FirstName = user.FirstName;
                dto.LastName = user.LastName;
                dto.UserName = user.UserName;
                dto.Email = user.Email;

                resultUserDtoList.Add(dto);
            }
            return View(resultUserDtoList);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            ViewBag.FullName = user.FirstName + ' ' + user.LastName;

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            List<AssignRoleDto> assignRoleDtoList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                var model = new AssignRoleDto();
                model.UserId = id;
                model.RoleName = role.Name;
                model.RoleId = role.Id;
                model.RoleExist = userRoles.Contains(role.Name);

                assignRoleDtoList.Add(model);
            }
            return View(assignRoleDtoList);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
        {
            var userId = model.Select(x => x.UserId).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());

            foreach (var role in model)
            {
                if (role.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
