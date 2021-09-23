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
            return new List<string> 
            {
                "hello",
                "world"
            };
        }
    }
}
