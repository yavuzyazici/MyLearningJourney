using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBannerController(IBannerService _bannerService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var values = _bannerService.TGetAll();

            var banners = _mapper.Map<List<ResultBannerDto>>(values);
            return View(banners);
        }
        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBanner(CreateBannerDto model)
        {
            _bannerService.TCreate(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteBanner(int id)
        {
            if (_bannerService.TGetAll().Count() == 1)
            {
                ModelState.AddModelError("YouCantDeleteAll", "You cant delete all Banners");
                return RedirectToAction("Index");
            }
            _bannerService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var data = _bannerService.TGetById(id);

            var banner = _mapper.Map<UpdateBannerDto>(data);
            return View(banner);
        }
        [HttpPost]
        public IActionResult UpdateBanner(UpdateBannerDto model)
        {
            _bannerService.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}
