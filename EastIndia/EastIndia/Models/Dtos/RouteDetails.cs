using System;

namespace EastIndia.Models.Dtos
{
    public class RouteDetails
    {
        public Guid FromCity { get; set; }
        public Guid ToCity { get; set; }
        public int Distance { get; set; }
        public int Price { get; set; }
        public int Time { get; set; }
    }
}