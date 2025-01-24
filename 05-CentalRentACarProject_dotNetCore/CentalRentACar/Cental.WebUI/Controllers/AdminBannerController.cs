using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
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
            var banner = _mapper.Map<Banner>(model);
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteBanner(int id)
        {
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
            var banner = _mapper.Map<Banner>(model);
            _bannerService.TUpdate(banner);
            return RedirectToAction("Index");
        }
    }
}
