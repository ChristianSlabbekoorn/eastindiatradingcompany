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
        public IEnumerable<string> GetAllRoutes()
        {
            return new List<string> 
            {
                "hello",
                "world"
            };
        }
    }
}
