using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MetaController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var meta = db.MyPortfolioTblMetas.FirstOrDefault();
            return View(meta);
        }
        [HttpPost]
        public ActionResult Index(MyPortfolioTblMeta metaData)
        {
            var meta = db.MyPortfolioTblMetas.FirstOrDefault();
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return RedirectToAction("Index", "Meta");
            }
            if (metaData.ogImage != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "wwwroot\\assets\\img\\og\\";
                var fileName = Path.Combine(saveLocation, metaData.ogImage.FileName);
                metaData.ogImage.SaveAs(fileName);
                metaData.PageOgImage = "/wwwroot/assets/img/og/" + metaData.ogImage.FileName;
            }
            meta.PageTitle = metaData.PageTitle;
            meta.PageDescription = metaData.PageDescription;
            meta.PageOgImage = metaData.PageOgImage;
            db.SaveChanges();
            return View(meta);
        }
    }
}