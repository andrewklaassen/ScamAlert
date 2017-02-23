using ScamAlert.Models;
using System.Web.Mvc;

namespace ScamAlert.Controllers
{
    public class ManageController : Controller
    {
        private aklaassenEntities1 sse = new aklaassenEntities1();

        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }
       
    }
}