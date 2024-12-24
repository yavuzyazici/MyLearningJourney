using RestaurantProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RestaurantProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email_username, string Password, string returnUrl)
        {
            var myUser = db.RestaurantAdmins.FirstOrDefault(x => (x.Email == email_username || x.UserName == email_username) && x.Password == Password);
            if (myUser == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View("Index");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(myUser.UserName, false);
                Session["UserId"] = myUser.AdminId;
                Session["NonReadedMessagesCount"] = db.RestaurantMessages.Count(x => x.IsRead == false);

                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Dashboard");
            }
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}