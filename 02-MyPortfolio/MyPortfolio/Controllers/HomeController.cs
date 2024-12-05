using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MyPortfolio.Models;
using System.Data.Entity;
using System.Reflection;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MyPortfolioTblMessage model)
        {
            model.MessageDate = DateTime.Now;
            model.IsRead = false;
            
            if (!ModelState.IsValid)
            {
                TempData["MessageErrors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Home");
            }

            db.MyPortfolioTblMessages.Add(model);
            db.SaveChanges();
            return View();
        }

        public PartialViewResult HomeHead()
        {
            var meta = db.MyPortfolioTblMetas.FirstOrDefault();
            return PartialView(meta);
        }
        public PartialViewResult HomeHeader()
        {
            return PartialView();
        }
        public PartialViewResult HomeBanner()
        {
            var banner = db.MyPortfolioTblBanners.Where(b => b.IsShown == true).FirstOrDefault();
            return PartialView(banner);
        }
        public PartialViewResult HomeAbout()
        {
            var about = db.MyPortfolioTblAbouts.FirstOrDefault();

            return PartialView(about);
        }
        public PartialViewResult HomeSocialMedia()
        {
            var socials = db.MyPortfolioTblSocialMedias.ToList();
            return PartialView(socials);
        }
        public PartialViewResult HomeExpertise()
        {
            var expertise = db.MyPortfolioTblExpertises.FirstOrDefault();
            return PartialView(expertise);
        }
        public PartialViewResult HomeExperience()
        {
            var experiences = db.MyPortfolioTblExperiences.OrderByDescending(x => x.StartDate).ToList();
            return PartialView(experiences);
        }
        public PartialViewResult HomeEducation()
        {
            var educations = db.MyPortfolioTblEducations.OrderByDescending(x => x.StartDate).ToList();
            return PartialView(educations);
        }
        public PartialViewResult HomeProjects()
        {
            var projects = db.MyPortfolioTblProjects.ToList();
            return PartialView(projects);
        }
        public PartialViewResult HomeTestimonials()
        {
            var testimonials = db.MyPortfolioTblTestimonials.ToList();
            return PartialView(testimonials);
        }
        public PartialViewResult HomeContact()
        {
            var contact = db.MyPortfolioTblContacts.FirstOrDefault();
            return PartialView(contact);
        }
        public PartialViewResult HomeFooter()
        {
            return PartialView();
        }
    }
}