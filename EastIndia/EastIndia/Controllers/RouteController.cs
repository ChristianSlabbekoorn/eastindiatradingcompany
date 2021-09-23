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
        public ExternalRouteDetails[] CalculateRoute([FromBody] Package body)
        {
            RouteCalculator routeCalculator = new RouteCalculator();
            routeCalculator.CalculateRoutes(body);
            return new ExternalRouteDetails[] { new ExternalRouteDetails(), new ExternalRouteDetails() };
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
