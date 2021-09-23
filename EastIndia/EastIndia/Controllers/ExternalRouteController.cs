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
        public IEnumerable<ExternalRouteDetails> GetAllRoutes([FromBody] Package body)
        {
            return new List<ExternalRouteDetails> 
            {
                new ExternalRouteDetails() 
                {
                    Start = Guid.NewGuid().ToString(),
                    Stop = Guid.NewGuid().ToString(),
                    Price = 42.ToString(),
                    Duration = 42.ToString()

                },
                new ExternalRouteDetails() 
                {
                    Start = Guid.NewGuid().ToString(),
                    Stop = Guid.NewGuid().ToString(),
                    Price = 42.ToString(),
                    Duration = 42.ToString()
                }
            };
        }
    }
}
