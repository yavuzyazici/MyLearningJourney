using RestaurantProject.Context;
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

            if (meta.ogImage != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\og\\";
                var fileName = Path.Combine(saveLocation, meta.ogImage.FileName.Replace(" ", "-"));
                meta.ogImage.SaveAs(fileName);
                meta.ImageUrl = "/assets/images/og/" + meta.ogImage.FileName.Replace(" ","-");
            }

            myMeta.Title = meta.Title;
            myMeta.Description = meta.Description;
            myMeta.ImageUrl = meta.ImageUrl;
            db.SaveChanges();
            return View(meta);
        }
    }
}