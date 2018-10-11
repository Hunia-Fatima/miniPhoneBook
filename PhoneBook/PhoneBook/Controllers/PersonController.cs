using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    public class PersonController : Controller
    {
        private PhoneBookDbEntities db = new PhoneBookDbEntities();
        // GET: Person
        public ActionResult Index()
        {
            List<Person> persons = db.People.ToList();
            List<PersonViewModel> List = new List<PersonViewModel>();
            foreach (Person p in persons)
            {
                PersonViewModel obj = new PersonViewModel();
                obj.FirstName = p.FirstName;
                obj.MiddleName = p.MiddleName;
                obj.LastName = p.LastName;
                obj.DateOfBirth = p.DateOfBirth.Value;
                obj.AddedBy = p.AddedBy;
                obj.HomeAddress = p.HomeAddress;
                obj.HomeCity = p.HomeCity;
                obj.FaceBookAccountId = obj.FaceBookAccountId;
                obj.LinkedInId = p.LinkedInId;
                obj.ImagePath = p.ImagePath;
                obj.TwitterId = p.TwitterId;
                obj.EmailId = p.EmailId;
                obj.AddedOn = p.AddedOn;
                obj.UpdateOn = p.UpdateOn.Value;
                List.Add(obj);
            }
            return View(List);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.AddedBy = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel obj)
        {
            try
            {
                Person P = new Person();
                P.PersonId = obj.PersonId;
                P.FirstName = obj.FirstName;
                P.MiddleName = obj.MiddleName;
                P.LastName = obj.LastName;
                P.DateOfBirth = obj.DateOfBirth;
                P.AddedOn = DateTime.Today;
                P.AddedBy = obj.AddedBy;
                P.HomeAddress = obj.HomeAddress;
                P.HomeCity = obj.HomeCity;
                P.FaceBookAccountId = obj.FaceBookAccountId;
                P.LinkedInId = P.LinkedInId;
                P.UpdateOn = DateTime.Today;
                P.ImagePath = obj.ImagePath;
                P.TwitterId = obj.TwitterId;
                P.EmailId = obj.EmailId;


                db.People.Add(P);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonViewModel obj)
        {
            try
            {
                foreach(Person P in db.People)
                {
                    if(P.PersonId == id)
                    {
                        P.PersonId = obj.PersonId;
                        P.FirstName = obj.FirstName;
                        P.MiddleName = obj.MiddleName;
                        P.LastName = obj.LastName;
                        P.DateOfBirth = obj.DateOfBirth;
                        P.AddedBy = obj.AddedBy;
                        P.HomeAddress = obj.HomeAddress;
                        P.HomeCity = obj.HomeCity;
                        P.FaceBookAccountId = obj.FaceBookAccountId;
                        P.LinkedInId = P.LinkedInId;
                        P.UpdateOn = DateTime.Today;
                        P.ImagePath = obj.ImagePath;
                        P.TwitterId = obj.TwitterId;
                        P.EmailId = obj.EmailId;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // : Add delete logic here
                foreach(Person p in db.People)
                {
                    if(p.PersonId == id)
                    {
                        db.People.Remove(p);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
