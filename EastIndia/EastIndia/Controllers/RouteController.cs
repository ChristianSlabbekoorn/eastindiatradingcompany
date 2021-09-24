using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

using EastIndia.Helpers;
using EastIndia.Managers;
using EastIndia.Models.Dtos;
using EastIndia.Services;

namespace EastIndia.Controllers
{
    public class RouteController : Controller
    {
        [System.Web.Mvc.HttpPost]
        public ActionResult CalculateRoute(Package body)
        {
            var routeCalculator = new RouteCalculator();
            routeCalculator.CalculateDistance(body);
            var routes = new List<ExternalRouteDetails> { new ExternalRouteDetails()
            {
                Start = "Cairo",
                Stop = "Kapstaden",
                Duration = "60",
                Price = "1000"
            }, new ExternalRouteDetails()
            {
                Start = "Hvalbugten",
                Stop = "Kapstaden",
                Duration = "60",
                Price = "1200"
            } };
            return View("Results", routes);

        }

        public bool GenerateFile([FromBody] RouteReport body)
        {
            return true;
        }

        public ActionResult ChangePrice([FromBody] PriceUpdate price)
        {
            var manager = new PriceManager(new DbHelper());
            return manager.UpdatePrice(price) ?
                new HttpStatusCodeResult(HttpStatusCode.OK) :
                new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

        public RouteDetails[] GetRoutesInfo([FromBody] Package body)
        {
            return new RouteDetails[] { new RouteDetails(), new RouteDetails() };
        }
    }
}
