using System;

namespace EastIndia.Models.Dtos
{
    public class RouteReport
    {
        public Guid FromCity { get; set; }
        public Guid ToCity { get; set; }
        public DateTime StartRangeDate { get; set; }
        public DateTime EndRangeDate { get; set; }
    }
}