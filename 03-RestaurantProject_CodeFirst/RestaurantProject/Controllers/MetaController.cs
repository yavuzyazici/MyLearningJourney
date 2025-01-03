﻿using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class MetaController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        public void SaveImage(RestaurantMeta meta)
        {
            if (meta.ogImage != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\og\\";
                var fileName = Path.Combine(saveLocation, meta.ogImage.FileName.Replace(" ", "-"));
                meta.ogImage.SaveAs(fileName);
                meta.ImageUrl = "/assets/images/og/" + meta.ogImage.FileName.Replace(" ", "-");
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            var meta = db.RestaurantMetas.FirstOrDefault();
            return View(meta);
        }

        [HttpPost]
        public ActionResult Index(RestaurantMeta meta)
        {
            var myMeta = db.RestaurantMetas.FirstOrDefault();

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Meta");
            }

            myMeta.Title = meta.Title;
            myMeta.Description = meta.Description;
            myMeta.ImageUrl = meta.ImageUrl;
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Update process completed successfully" };

            return View(meta);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var meta = db.RestaurantMetas.Find(id);
            var metaCount = db.RestaurantMetas.Count();

            if (metaCount <= 1)
            {
                ModelState.AddModelError("DeleteMeta", "You cant delete all Metas");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Meta");
            }

            db.RestaurantMetas.Remove(meta);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Delete process completed successfully" };

            return RedirectToAction("Index", "Meta");
        }

        [HttpGet]
        public ActionResult AddMeta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMeta(RestaurantMeta meta)
        {
            int metaCount = db.RestaurantMetas.Count();
            if (metaCount <= 1)
            {
                ModelState.AddModelError("AddMeta", "You cant add meta while you have meta.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Meta");
            }
            db.RestaurantMetas.Add(meta);
            SaveImage(meta);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Meta");
        }
    }
}