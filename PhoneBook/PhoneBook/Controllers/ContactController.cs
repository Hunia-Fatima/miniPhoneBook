using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    public class ContactController : Controller
    {
        private PhoneBookDbEntities db = new PhoneBookDbEntities();
        // GET: Contact
        public ActionResult Index()
        {
            List<Contact> contacts = db.Contacts.ToList();
            List<ContactViewModel> list = new List<ContactViewModel>();
            foreach(Contact c in contacts)
            {
                ContactViewModel contact = new ContactViewModel();
                contact.ContactId = c.ContactId;
                contact.ContactNumber = c.ContactNumber;
                contact.Type = c.Type;
                contact.PersonId = c.PersonId;
                list.Add(contact);
            }
            return View(list);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName");
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactViewModel obj)
        {
            try
            {
                Contact C = new Contact();
                C.ContactId = obj.ContactId;
                C.ContactNumber = obj.ContactNumber;
                C.Type = obj.Type;
                C.PersonId = obj.PersonId;
                db.Contacts.Add(C);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactViewModel obj)
        {
            try
            {
                // TODO: Add update logic here
                Contact C = db.Contacts.Find(id);
                C.ContactId = obj.ContactId;
                C.ContactNumber = obj.ContactNumber;
                C.Type = obj.Type;
                C.PersonId = obj.PersonId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
