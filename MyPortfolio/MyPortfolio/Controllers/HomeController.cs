using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MyPortfolio.Models;
using System.Data.Entity;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var Banner = db.MyPortfolioTblBanners.FirstOrDefault();

            ViewBag.BannerTitle = Banner.Title;
            ViewBag.BannerDescription = Banner.Description;

            var About = db.MyPortfolioTblAbouts.FirstOrDefault();
            ViewBag.AboutTitle = About.Title;
            ViewBag.AboutDescription = About.Description;
            ViewBag.AboutImageURL = About.ImageUrl;
            ViewBag.AboutCvURL = About.CvUrl;

            var Expertise = db.MyPortfolioTblExpertises.FirstOrDefault();
            ViewBag.ExpertiseTitle = Expertise.Title;
            ViewBag.ExpertiseDescription = Expertise.Description;

            var Experiences = db.MyPortfolioTblExperiences.ToList().OrderByDescending(x=>x.StartDate);
            ViewBag.Experiences = Experiences;

            var Educations = db.MyPortfolioTblEducations.ToList().OrderByDescending(x => x.StartDate);
            ViewBag.Educations = Educations;

            var Projects = db.MyPortfolioTblProjects.ToList();
            ViewBag.Projects = Projects; 

            var Testimonials = db.MyPortfolioTblTestimonials.ToList();
            ViewBag.Testimonials = Testimonials;

            var Contact = db.MyPortfolioTblContacts.FirstOrDefault();
            ViewBag.Contact = Contact;

            var Socials = db.MyPortfolioTblSocialMedias.ToList();
            ViewBag.Socials = Socials;

            return View();
        }

        [HttpPost]
        public ActionResult Index(MyPortfolioTblMessage model)
        {
            model.MessageDate = DateTime.Now;
            // Modelin doğruluğunu kontrol et
            if (ModelState.IsValid)
            {
                    model.IsRead = false;  // Yeni mesaj olarak işaretle
                    db.MyPortfolioTblMessages.Add(model);  // Mesajı veritabanına ekle
                    db.SaveChanges();  // Değişiklikleri kaydet

                    return RedirectToAction("Index", "Home");
            }

            return View(); 
        }
    }
}