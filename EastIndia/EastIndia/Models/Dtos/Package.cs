using System;
using System.ComponentModel.DataAnnotations;

namespace EastIndia.Models.Dtos
{
    public class Package
    {
        [Display(Name = "From")]
        public Guid? FromCity { get; set; }

        [Display(Name = "To")]
        public Guid? ToCity { get; set; }

        [Display(Name = "Cautious")]

        public bool IsCautious { get; set; }

        [Display(Name = "Refrigerated")]

        public bool IsRefrigerated { get; set; }

        [Display(Name = "Weapons")]

        public bool IsWeapons { get; set; }

        [Display(Name = "Recorded")]

        public bool IsRecorded { get; set; }

        [Display(Name = "Animals")]

        public bool IsAnimals { get; set; }

        [Display(Name = "Other")]

        public bool Other { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
    }
}