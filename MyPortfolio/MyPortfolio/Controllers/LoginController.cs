using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email_username, string Password)
        {
            var myUser = db.TblUsers.FirstOrDefault(x => (x.EMail == email_username || x.UserName == email_username) & x.Password == Password);
            if (myUser == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(myUser.UserName, false);
                Session["UserId"] = myUser.Id;
                Session["Username"] = myUser.UserName;
                return RedirectToAction("Index", "Banner");
            }
        }
    }
}