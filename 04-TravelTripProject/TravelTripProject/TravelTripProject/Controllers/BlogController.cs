using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogComment bc = new BlogComment();
        public ActionResult Index()
        {
            bc.Blogs = c.Blogs.ToList();
            bc.Last3Blog = c.Blogs.Take(3).OrderByDescending(x => x.CreationDate).ToList();
            bc.Last3Comment = c.Comments.Take(3).OrderByDescending(x => x.Id).ToList();
            return View(bc);
        }
        public ActionResult BlogDetail(int id)
        {
            bc.Blogs = c.Blogs.Where(x => x.Id == id).ToList();

            bc.Comments = c.Comments.Where(x => x.BlogId == id).ToList();
            return View(bc);
        }
        [HttpPost]
        public ActionResult BlogDetail(Comment comment)
        {
            c.Comments.Add(comment);
            c.SaveChanges();
            return RedirectToAction("BlogDetail", "Blog", new { id = comment.BlogId });
        }

    }
}