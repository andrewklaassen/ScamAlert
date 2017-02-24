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
        //TODO: Need to build Scam Report method

    }
}