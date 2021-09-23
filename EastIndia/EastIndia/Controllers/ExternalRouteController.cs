using EastIndia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EastIndia.Controllers
{
    public class ExternalRouteController : ApiController
    {
        [HttpGet]
        public IEnumerable<RouteDetails> GetAllRoutes([FromBody] Package body)
        {
            return new List<RouteDetails> 
            {
                new RouteDetails() 
                {
                    FromCity = Guid.NewGuid(),
                    ToCity = Guid.NewGuid(),
                    Distance = 42,
                    Price = 42,
                    Time = 42

                },
                new RouteDetails() 
                {
                    FromCity = Guid.NewGuid(),
                    ToCity = Guid.NewGuid(),
                    Distance = 42,
                    Price = 42,
                    Time = 42
                }
            };
        }
    }
}
