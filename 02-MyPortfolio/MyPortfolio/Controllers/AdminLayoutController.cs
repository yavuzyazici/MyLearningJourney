using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        public ActionResult Layout()
        {
            return View();
        }
        public ActionResult AdminLayoutHead()
        {
            Session["NonReadedMessagesCount"] = db.MyPortfolioTblMessages.Count(x => x.IsRead == false);
            return PartialView();
        }
        public ActionResult AdminLayoutNavbar()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var user = db.TblUsers.FirstOrDefault(x => x.Id == userId);

            var messages = db.MyPortfolioTblMessages.Where(x => x.IsRead == false).Take(3).ToList();
            Session["Messages"] = messages;
            return PartialView(user);
        }
        public ActionResult AdminLayoutErrors()
        {
            return PartialView();
        }
        public ActionResult AdminLayoutFooter()
        {
            return PartialView();
        }
        public ActionResult AdminLayoutScripts()
        {
            return PartialView();
        }
    }
}