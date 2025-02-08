using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController(IBrandService _brandService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var values = _brandService.TGetAll();
            var brands = _mapper.Map<List<ResultBrandDto>>(values);
            return View(brands);
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBrand(CreateBrandDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _brandService.TCreate(model);
            return RedirectToAction("Index", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult DeleteBrand(int id)
        {
            if (_brandService.TGetAll().Count() == 1)
            {
                ModelState.AddModelError("YouCantDeleteAll", "You cant delete all brands");
                return RedirectToAction("Index", new { area = "Admin" });
            }
            _brandService.TDelete(id);

            return RedirectToAction("Index", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var value = _brandService.TGetById(id);
            var brand = _mapper.Map<UpdateBrandDto>(value);
            return View(brand);
        }
        [HttpPost]
        public IActionResult UpdateBrand(UpdateBrandDto model)
        {
            _brandService.TUpdate(model);

            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
