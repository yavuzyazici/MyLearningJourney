using System.Linq;
using System.Web.Mvc;
using MyPortfolio.Models;
namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        DbAIOEntities1 db = new DbAIOEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.MyPortfolioTblContacts.FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(MyPortfolioTblContact contact)
        {
            var myContact = db.MyPortfolioTblContacts.FirstOrDefault();
            myContact.Phone = contact.Phone;
            myContact.Email = contact.Email;
            myContact.Title = contact.Title;
            myContact.Description = contact.Description;
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Contact");
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }

        [HttpGet]
        public ActionResult Messages()
        {
            var data = db.MyPortfolioTblMessages.OrderByDescending(x=> x.IsRead == false).ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Read(MyPortfolioTblMessage Message)
        {
            var myMessage = db.MyPortfolioTblMessages.Find(Message.MessageId);
            myMessage.IsRead = Message.IsRead;
            db.SaveChanges();
            return RedirectToAction("Messages", "Contact");
        }
        [HttpPost]
        public ActionResult Delete(int MessageId)
        {
            var myMessage = db.MyPortfolioTblMessages.FirstOrDefault(x => x.MessageId == MessageId);
            db.MyPortfolioTblMessages.Remove(myMessage);
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Contact");
            }
            db.SaveChanges();
            return RedirectToAction("Messages", "Contact");
        }
    }
}