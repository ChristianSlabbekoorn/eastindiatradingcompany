using System;

namespace EastIndia.Models.Dtos
{
    public class ExternalPackage
    {
        public bool IsCautious { get; set; }
        public bool IsRefrigerated { get; set; }
        public bool IsWeapons { get; set; }
        public bool IsRecorded { get; set; }
        public bool IsAnimals { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

    }
}