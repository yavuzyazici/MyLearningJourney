using System.Linq;
using System.Web.Mvc;
using MyPortfolio.Models;
namespace MyPortfolio.Controllers
{
    [Authorize]
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
            db.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }

        [HttpGet]
        public ActionResult Messages()
        {
            var data = db.MyPortfolioTblMessages.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Read(int MessageId, bool IsRead)
        {
            var myMessage = db.MyPortfolioTblMessages.FirstOrDefault(x => x.MessageId == MessageId);
            myMessage.IsRead = IsRead;
            db.SaveChanges();
            return RedirectToAction("Messages", "Contact");
        }
        [HttpPost]
        public ActionResult Delete(int MessageId)
        {

            return RedirectToAction("Messages", "Contact");
        }
    }
}