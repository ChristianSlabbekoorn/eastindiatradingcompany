using System;

namespace EastIndia.Models.Dtos
{
    public class RouteHop
    {
        public Guid FromCity { get; set; }
        public Guid ToCity { get; set; }
        public int Segments { get; set; }
    }
}