//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EastIndia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Price
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Price()
        {
            this.Packages = new HashSet<Package>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> WeightID { get; set; }
        public Nullable<System.Guid> PeriodID { get; set; }
        public Nullable<decimal> RefrigeratedFee { get; set; }
        public Nullable<decimal> WeaponFee { get; set; }
        public Nullable<decimal> LiveAnimalFee { get; set; }
        public Nullable<decimal> PricePerSegment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package> Packages { get; set; }
        public virtual Period Period { get; set; }
        public virtual Weight Weight { get; set; }
    }
}