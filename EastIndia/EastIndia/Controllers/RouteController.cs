using System.Net;
using System.Web.Http;
using System.Web.Mvc;

using EastIndia.Managers;
using EastIndia.Models.Dtos;

namespace EastIndia.Controllers
{
    public class RouteController : Controller
    {
        public Route[] CalculateRoute([FromBody] Package body)
        {
            return new Route[] { new Route(), new Route() };
        }

        public bool GenerateFile([FromBody] RouteReport body)
        {
            return true;
        }

        public ActionResult ChangePrice([FromBody] PriceUpdate price)
        {
            return PriceManager.UpdatePrice(price) ?
                new HttpStatusCodeResult(HttpStatusCode.OK) :
                new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

        public RouteDetails[] GetRoutesInfo([FromBody] Package body)
        {
            return new RouteDetails[] { new RouteDetails(), new RouteDetails() };
        }
    }
}
