using MyPortfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
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