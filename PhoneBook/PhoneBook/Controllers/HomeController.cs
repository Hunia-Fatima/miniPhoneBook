using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        private PhoneBookDbEntities db = new PhoneBookDbEntities();
        public ActionResult Index()
        {
            int numberOfContacts = db.People.ToArray().Length;
            return View(numberOfContacts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}