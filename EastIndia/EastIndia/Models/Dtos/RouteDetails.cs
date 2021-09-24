using System;

namespace EastIndia.Models.Dtos
{
    public class RouteDetails
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public int Distance { get; set; }
        public int Price { get; set; }
        public int Time { get; set; }
    }
}