using MyPortfolio.Models;
using System.Linq;
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
                ModelState.AddModelError("", "Email or password is incorrect");
                return View("Index");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(myUser.UserName, false);
                Session["UserId"] = myUser.Id;
                
                return RedirectToAction("Index", "Meta");
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