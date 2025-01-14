using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var values = _aboutService.TGetAll();

            var result = values.Select(about => new ResultAboutDto
            {
                AboutId = about.AboutId,
                Mission = about.Mission,
                Vision = about.Vision
            }).ToList();

            return View(result);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto model)
        {
            var about = new About()
            {
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrlSmall = model.ImageUrlSmall,
                ImageUrlBig = model.ImageUrlBig,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePictureUrl = model.ProfilePictureUrl,
                StartYear = model.StartYear,
                Vision = model.Vision
            };

            _aboutService.TCreate(about);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var model = _aboutService.TGetById(id);
            var about = new UpdateAboutDto()
            {
                AboutId = model.AboutId,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrlSmall = model.ImageUrlSmall,
                ImageUrlBig = model.ImageUrlBig,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePictureUrl = model.ProfilePictureUrl,
                StartYear = model.StartYear,
                Vision = model.Vision
            };
            return View(about);
        }
        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto model)
        {
            var about = new About()
            {
                AboutId = model.AboutId,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrlSmall = model.ImageUrlSmall,
                ImageUrlBig = model.ImageUrlBig,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePictureUrl = model.ProfilePictureUrl,
                StartYear = model.StartYear,
                Vision = model.Vision
            };
            _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
