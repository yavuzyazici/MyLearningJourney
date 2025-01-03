using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Context c = new Context();

        #region Blog
        [HttpGet]
        public ActionResult Blog()
        {
            var blogs = c.Blogs.ToList();
            return View(blogs);
        }
        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBlog(Blog blog)
        {
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Blog", "Admin");
        }
        [HttpGet]
        public ActionResult DeleteBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Blog", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog blog)
        {
            var myBlog = c.Blogs.Find(blog.Id);

            myBlog.Title = blog.Title;
            myBlog.Content = blog.Content;
            myBlog.CreationDate = blog.CreationDate;
            myBlog.ImageUrl = blog.ImageUrl;

            c.SaveChanges();

            return RedirectToAction("Blog", "Admin");
        }
        public ActionResult BlogDetail(int id)
        {
            var blog = c.Blogs.Find(id);
            return View(blog);
        }
        #endregion

        #region Comment
        [HttpGet]
        public ActionResult Comment()
        {
            var comment = c.Comments.OrderByDescending(x => x.BlogId).ToList();
            return View(comment);
        }
        [HttpGet]
        public ActionResult DeleteComment(int id)
        {
            var comment = c.Comments.Find(id);
            c.Comments.Remove(comment);
            c.SaveChanges();

            return RedirectToAction("Comment", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateComment(int id)
        {
            var comment = c.Comments.Find(id);
            return View(comment);
        }
        [HttpPost]
        public ActionResult UpdateComment(Comment comment)
        {
            var myComment = c.Comments.Find(comment.Id);
            myComment.UserName = comment.UserName;
            myComment.Mail = comment.Mail;
            myComment.Content = comment.Content;

            return RedirectToAction("Comment", "Admin");
        }
        [HttpGet]
        public ActionResult CommentDetail(int id)
        {
            var comment = c.Comments.Find(id);
            return View(comment);
        }
        #endregion

        #region Contact
        [HttpGet]
        public ActionResult Contact()
        {
            var contacts = c.Contacts.ToList();
            return View(contacts);
        }
        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            var contact = c.Contacts.Find(id);
            c.Contacts.Remove(contact);
            c.SaveChanges();
            return RedirectToAction("Contact", "Admin");
        }
        [HttpGet]
        public ActionResult ContactDetail(int id)
        {
            var contact = c.Contacts.Find(id);
            return View(contact);
        }
        #endregion

        #region About
        [HttpGet]
        public ActionResult About()
        {
            var about = c.Abouts.FirstOrDefault();
            return View(about);
        }
        [HttpGet]
        public ActionResult UpdateAbout()
        {
            var about = c.Abouts.FirstOrDefault();
            return View(about);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var myAbout = c.Abouts.FirstOrDefault();
            myAbout.Description = about.Description;
            myAbout.ImageUrl     = about.ImageUrl;
            c.SaveChanges();
            return RedirectToAction("About", "Admin");
        }
        #endregion
    }
}
