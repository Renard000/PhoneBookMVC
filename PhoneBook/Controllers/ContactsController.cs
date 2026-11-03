using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class ContactsController : Controller
    {
        private readonly PhoneBookContext PhoneBookContext = new PhoneBookContext();
        
        // GET: Contacts
        public ActionResult Index()
        {
            List<Contact> contacts = PhoneBookContext.Contacts.ToList();
            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Phone,Email")]  Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            PhoneBookContext.Contacts.Add(contact);
            PhoneBookContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Contact contact = PhoneBookContext.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Editpost(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            
            var contact = PhoneBookContext.Contacts.Find(id);

            if (contact == null)
            {
                return HttpNotFound();
            }

            if (TryUpdateModel(contact, "", new string[] { "FirstName", "LastName", "Phone", "Email" }))
            {
                PhoneBookContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);

        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Contact contact = PhoneBookContext.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Contact contact = PhoneBookContext.Contacts.Find(id);

            if(contact == null)
            {
                return HttpNotFound();
            }


            PhoneBookContext.Contacts.Remove(contact);
            PhoneBookContext.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PhoneBookContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}