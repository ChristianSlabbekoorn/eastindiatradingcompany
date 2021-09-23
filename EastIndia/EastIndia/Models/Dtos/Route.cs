using System;

namespace EastIndia.Models.Dtos
{
    public class Route
    {
        public Guid FromCity { get; set; }
        public Guid ToCity { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public Priority Priority { get; set; }

    }
}