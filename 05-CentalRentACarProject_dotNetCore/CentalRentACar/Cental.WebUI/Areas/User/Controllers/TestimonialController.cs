using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Authorize(Roles ="User")]
    [Area("User")]
    public class TestimonialController(ITestimonialService _testimonialService,UserManager<AppUser> _userManager, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _testimonialService.GetByUserName(User.Identity.Name);
            var testimonial = _mapper.Map<ResultTestimonialDto>(data);
            return View(testimonial);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> CreateTestimonial(CreateTestimonialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (_testimonialService.GetByUserName(user.UserName) != null)
            {
                ModelState.AddModelError("", "You cant add more than 1 testimonial");
                return RedirectToAction("Index", new { area = "User" });
            }
            model.UserId = user.Id;
            model.NameSurname = $"{user.FirstName} {user.LastName}";
            model.IsAproved = false;
            model.ImageUrl = user.ImageUrl;

            _testimonialService.TCreate(model);
            return RedirectToAction("Index", new { area = "User" });
        }
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var data = _testimonialService.TGetById(id);
            var testimonial = _mapper.Map<UpdateTestimonialDto>(data);
            return View(testimonial);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            model.UserId = user.Id;
            model.NameSurname = $"{user.FirstName} {user.LastName}";
            model.IsAproved = false;
            model.ImageUrl = user.ImageUrl;
            _testimonialService.TUpdate(model);
            return RedirectToAction("Index", new { area = "User" });
        }
    }
}
