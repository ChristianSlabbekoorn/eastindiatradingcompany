using System;

namespace EastIndia.Models.Dtos
{
    public class SeasonalPrice
    {
        public Guid Season { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
}