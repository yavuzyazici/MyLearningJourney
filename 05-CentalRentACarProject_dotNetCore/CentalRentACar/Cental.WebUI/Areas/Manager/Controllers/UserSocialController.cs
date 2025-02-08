using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class UserSocialController(IUserSocialService _userSocialService, IMapper _mapper, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userSocials = _userSocialService.TGetSocialsByUserId(user.Id);
            return View(userSocials);
        }
        [HttpGet]
        public IActionResult CreateSocial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateUserSocialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            model.UserId = user.Id;

            _userSocialService.TCreate(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteSocial(int id)
        {
            _userSocialService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSocial(int id)
        {
            var data = _userSocialService.TGetById(id);
            var user = _mapper.Map<UpdateUserSocialDto>(data);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocial(UpdateUserSocialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            model.UserId = user.Id;

            _userSocialService.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}