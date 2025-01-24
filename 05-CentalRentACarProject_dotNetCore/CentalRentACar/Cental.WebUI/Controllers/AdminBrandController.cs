﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Cental.WebUI.Controllers
{
    public class AdminBrandController(IBrandService _brandService, IMapper _mapper) : Controller
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
            var brand = _mapper.Map<Brand>(model);
            _brandService.TCreate(brand);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);

            return RedirectToAction("Index");
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
            var brand = _mapper.Map<Brand>(model);
            _brandService.TUpdate(brand);

            return RedirectToAction("Index");
        }
    }
}
