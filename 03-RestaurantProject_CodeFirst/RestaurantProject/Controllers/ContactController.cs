using RestaurantProject.Context;
using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class ContactController : Controller
    {
        RestaurantContext db = new RestaurantContext();

        [HttpGet]
        public ActionResult Index()
        {
            var contactInfo = db.RestaurantContactInfo.FirstOrDefault();
            return View(contactInfo);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var contactInfo = db.RestaurantContactInfo.Find(id);
            return View(contactInfo);
        }
        [HttpPost]
        public ActionResult Update(RestaurantContactInfo contactInfoData)
        {
            var contactInfo = db.RestaurantContactInfo.Find(contactInfoData.RestaurantContactInfoId);

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Contact");
            }

            contactInfo.Address = contactInfoData.Address;
            contactInfo.Email = contactInfoData.Email;
            contactInfo.PhoneNumber = contactInfoData.PhoneNumber;
            contactInfo.MapUrl = contactInfoData.MapUrl;
            contactInfo.OpenHours = contactInfoData.OpenHours;

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Update process completed successfully" };

            return RedirectToAction("Index", "Contact");
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(RestaurantContactInfo contact)
        {
            int contactCount = db.RestaurantContactInfo.Count();
            if (contactCount <= 1)
            {
                ModelState.AddModelError("AddContactInfo", "You cant add contact info while you have.");
            }
            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Index", "Contact");
            }

            db.RestaurantContactInfo.Add(contact);

            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Adding process completed successfully" };

            return RedirectToAction("Index", "Contact");
        }
        [HttpGet]
        public ActionResult Messages()
        {
            var messages = db.RestaurantMessages.OrderByDescending(x => x.IsRead == false).ToList();
            return View(messages);
        }
        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            var message = db.RestaurantMessages.Find(id);
            if (message.IsRead == true)
            {
                message.IsRead = false;
            }
            else
            {
                message.IsRead = true;
            }

            if (!ModelState.IsValid)
            {
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                return RedirectToAction("Messages", "Contact");
            }


            db.SaveChanges();

            Session["NonReadedMessagesCount"] = db.RestaurantMessages.Count(x => x.IsRead == false);

            TempData["Success"] = new List<string>() { "Status changing process completed successfully" };

            return RedirectToAction("Messages", "Contact");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var message = db.RestaurantMessages.Find(id);

            db.RestaurantMessages.Remove(message);
            db.SaveChanges();

            TempData["Success"] = new List<string>() { "Message deleted successfully" };

            return RedirectToAction("Messages", "Contact");
        }
    }
}