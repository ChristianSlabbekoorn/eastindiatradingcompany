using EastIndia.Models.Dtos;
using EastIndia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

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

        public bool ChangeSeasonalPrice([FromBody] SeasonalPrice body)
        {
            return true;
        }

        public bool ChangeTypePrice([FromBody] PackageTypePrice body)
        {
            return true;
        }

        public RouteDetails[] GetRoutesInfo([FromBody] Package body)
        {
            return new RouteDetails[] { new RouteDetails(), new RouteDetails() };
        }
    }
}
