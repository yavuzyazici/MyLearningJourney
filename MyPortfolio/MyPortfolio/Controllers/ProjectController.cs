using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;


namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblProjects.ToList();
            var categoryData = db.MyPortfolioTblCategories.ToList();

            //List<SelectListItem> categories = (from x in categoryData
            //                                   select new SelectListItem
            //                                   {
            //                                       Text = x.Name,
            //                                       Value = x.CategoryId.ToString()
            //                                   }).ToList();

            ViewBag.Categories = categoryData;

            return View(data);
        }
        public void SaveImage(MyPortfolioTblProject project)
        {
            if (project.ProjectImage != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "wwwroot\\assets\\img\\";
                var fileName = Path.Combine(saveLocation, project.ProjectImage.FileName);
                project.ProjectImage.SaveAs(fileName);
                project.ImageUrl = "/wwwroot/assets/img/" + project.ProjectImage.FileName;
            }
        }
        [HttpPost]
        public ActionResult Add(MyPortfolioTblProject project)
        {
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Project");
            }
            SaveImage(project);
            db.MyPortfolioTblProjects.Add(project);
            db.SaveChanges();

            return RedirectToAction("Index", "Project");
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblProject project)
        {
            var myProject = db.MyPortfolioTblProjects.Find(project.ProjectId);
            
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = db.MyPortfolioTblCategories.ToList();

                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Project");
            }
            SaveImage(project);
            
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