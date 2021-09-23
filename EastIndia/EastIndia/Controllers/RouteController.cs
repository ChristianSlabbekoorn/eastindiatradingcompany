using EastIndia.Models.Dtos;
using EastIndia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            RouteCalculator calculator = new RouteCalculator();
            calculator.CalculateDistance();

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
