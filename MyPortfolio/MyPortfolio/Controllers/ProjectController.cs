using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblProjects.ToList();
            var categories = db.MyPortfolioTblCategories.ToList();
            ViewBag.Categories = categories;
            return View(data);
        }
        [HttpPost]
        public ActionResult Add(MyPortfolioTblProject project)
        {
            db.MyPortfolioTblProjects.Add(project);
            db.SaveChanges();

            return RedirectToAction("Index", "Project");
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblProject project)
        {
            var myProject = db.MyPortfolioTblProjects.Find(project.ProjectId);
            myProject.Name = project.Name;
            myProject.ImageUrl = project.ImageUrl;
            myProject.Description = project.Description;
            myProject.CategoryId = project.CategoryId;
            myProject.GithubUrl = project.GithubUrl;
            db.SaveChanges();

            return RedirectToAction("Index", "Project");
        }
        [HttpPost]
        public ActionResult Delete(int projectId)
        {
            var myProject = db.MyPortfolioTblProjects.Find(projectId);
            db.MyPortfolioTblProjects.Remove(myProject);
            db.SaveChanges();

            return RedirectToAction("Index", "Project");
        }
    }
}