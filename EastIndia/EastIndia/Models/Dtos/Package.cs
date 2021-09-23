using System;

namespace EastIndia.Models.Dtos
{
    public class Package
    {
        public Guid? FromCity { get; set; }
        public Guid? ToCity { get; set; }
        public bool IsCautious { get; set; }
        public bool IsRefrigerated { get; set; }
        public bool IsWeapons { get; set; }
        public bool IsRecorded { get; set; }
        public bool IsAnimals { get; set; }
        public int Weight { get; set; }

    }
}