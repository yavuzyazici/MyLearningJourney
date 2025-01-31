using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProfileController(UserManager<AppUser> _userManager, IImageService _imageService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _userManager.FindByNameAsync(User.Identity.Name);

            var user = data.Adapt<UpdateUserDto>();

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var checkPassword = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);

            if (checkPassword)
            {
                if (model.ImageFile != null)
                {
                    try
                    {
                        model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(model);
                    }
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.ImageUrl = model.ImageUrl;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    var count = 1;
                    ModelState.AddModelError($"ProfileError{count}", error.Description);
                    count++;
                }
                return View(model);
            }
            ModelState.AddModelError("ProfileUpdateError", "Incorrect password");
            return View(model);
        }
    }
}
