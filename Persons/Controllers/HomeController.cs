using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Persons.Models;

namespace Persons.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Health Cathalyst Cafe.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Contact Us";

            return View();
        }

        [ChildActionOnly]
        public ActionResult _Persons() {
            PersonsEntities context = new PersonsEntities();
            return PartialView("_Persons", context.Persons);
        }

        public ActionResult Find(string name) {
            PersonsEntities context = new PersonsEntities();
            name = System.Web.HttpUtility.UrlDecode(name);
            var q = context.Persons.Where(w => w.PersonNames.Contains(name)).Select(s => s);
            return PartialView("_Persons", q);
        }
    }
}