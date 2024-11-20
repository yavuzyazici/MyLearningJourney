using MyPortfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblTestimonials.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Add(MyPortfolioTblTestimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Testimonial");
            }
            db.MyPortfolioTblTestimonials.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index", "Testimonial");
        }

        [HttpPost]
        public ActionResult Update(MyPortfolioTblTestimonial testimonial)
        {
            var myTestimonial = db.MyPortfolioTblTestimonials.Find(testimonial.TestimonialId);
            myTestimonial.NameSurname = testimonial.NameSurname;
            myTestimonial.Title = testimonial.Title;
            myTestimonial.ImageUrl = testimonial.ImageUrl;
            myTestimonial.Comment = testimonial.Comment;
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Testimonial");
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Testimonial");
        }

        [HttpPost]
        public ActionResult Delete(int TestimonialId)
        {
            var myTestimonial = db.MyPortfolioTblTestimonials.Find(TestimonialId);
            db.MyPortfolioTblTestimonials.Remove(myTestimonial);
            db.SaveChanges();
            return RedirectToAction("Index", "Testimonial");
        }
    }
}