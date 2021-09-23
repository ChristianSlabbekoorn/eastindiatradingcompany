using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EastIndia.Models.Dtos
{
    public class ExternalRouteDetails
    {
        public string Start { get; set; }

        public string Stop { get; set; }

        public string Price { get; set; }

        public string Duration { get; set; }
    }
}