﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Cental.WebUI.Controllers
{
    public class AdminFeatureController(IFeatureService _featureService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _featureService.TGetAll();
            var features = _mapper.Map<List<ResultFeatureDto>>(data);
            return View(features);
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto data)
        {
            var feature = _mapper.Map<Feature>(data);
            _featureService.TCreate(feature);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var data = _featureService.TGetById(id);
            var feature = _mapper.Map<UpdateFeatureDto>(data);
            return View(feature);
        }
        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDto data)
        {
            var feature = _mapper.Map<Feature>(data);
            _featureService.TUpdate(feature);
            return RedirectToAction("Index");
        }
    }
}
