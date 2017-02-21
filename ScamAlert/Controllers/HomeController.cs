using ScamAlert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScamAlert.Controllers
{
    public class HomeController : Controller
    {
        private aklaassenEntities1 db = new aklaassenEntities1();

        public ActionResult Index()
        {
            var sCAM = db.Scams;
            return View(sCAM.ToList());
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