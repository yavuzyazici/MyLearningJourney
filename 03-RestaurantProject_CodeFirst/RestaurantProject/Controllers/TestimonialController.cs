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
    public class TestimonialController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        public void SaveImage(RestaurantTestimonial testimonial)
        {
            if (testimonial.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\images\\testimonial\\";
                var fileName = Path.Combine(saveLocation, testimonial.ImageFile.FileName.Replace(" ", "-"));
                testimonial.ImageFile.SaveAs(fileName);
                testimonial.ImageUrl = "/assets/images/testimonial/" + testimonial.ImageFile.FileName.Replace(" ", "-");
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            var testimonials = db.RestaurantTestimonials.ToList();
            return View(testimonials);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var testimonial = db.RestaurantTestimonials.Find(id);
            var testimonialCount = db.RestaurantTestimonials.Count();

            if (testimonialCount <= 1)
            {
                ModelState.AddModelError("DeleteTestimonial", "You cant delete all testimonials.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Testimonial");
            }

            db.RestaurantTestimonials.Remove(testimonial);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Deleting process completed successfully" };

            return RedirectToAction("Index", "Testimonial");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var testimonial = db.RestaurantTestimonials.Find(id);
            return View(testimonial);
        }
        [HttpPost]
        public ActionResult Update(RestaurantTestimonial testimonial)
        {
            var myTestimonial = db.RestaurantTestimonials.Find(testimonial.RestaurantTestimonialId);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Testimonial");
            }

            myTestimonial.NameSurname = testimonial.NameSurname;
            myTestimonial.Title = testimonial.Title;
            myTestimonial.Comment = testimonial.Comment;
            myTestimonial.Review = testimonial.Review;
            SaveImage(testimonial);
            myTestimonial.ImageUrl = testimonial.ImageUrl;

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Updating process completed successfully" };

            return RedirectToAction("Index", "Testimonial");
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(RestaurantTestimonial testimonial)
        {
            int testimonialCount = db.RestaurantTestimonials.Count();
            if (testimonialCount >= 10)
            {
                ModelState.AddModelError("AddTestimonial", "You cant add more than 10 testimonial.");
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Testimonial");
            }
            SaveImage(testimonial);

            db.RestaurantTestimonials.Add(testimonial);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Testimonial");
        }
    }
}