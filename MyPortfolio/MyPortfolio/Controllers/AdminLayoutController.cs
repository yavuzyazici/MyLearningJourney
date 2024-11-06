using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        public ActionResult Layout()
        {
            return View();
        }

        public ActionResult AdminLayoutHead()
        {
            return PartialView();
        }
    }
}