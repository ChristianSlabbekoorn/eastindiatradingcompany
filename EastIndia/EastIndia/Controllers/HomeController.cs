using System.Web.Mvc;

namespace EastIndia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Confirmation()
        {
            ViewBag.Message = "Confirmation shipping page.";

            return View();
        }
        public ActionResult Search()
        {
            ViewBag.Message = "Search routes page.";

            return View();
        }
    }
}