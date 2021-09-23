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
    
    public partial class RouteHop
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> StartLocationID { get; set; }
        public Nullable<System.Guid> EndLocationID { get; set; }
        public Nullable<System.Guid> PackageID { get; set; }
        public Nullable<byte> HopNo { get; set; }
        public Nullable<byte> TotalHops { get; set; }
        public Nullable<bool> Shipped { get; set; }
    
        public virtual Location EndLocation { get; set; }
        public virtual Location StartLocation { get; set; }
        public virtual Package Package { get; set; }
    }
}