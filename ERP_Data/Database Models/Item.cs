//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_Data.Database_Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int IDItem { get; set; }
        public int AddDate { get; set; }
        public byte[] Imag { get; set; }
        public string NameIt { get; set; }
        public int GroupIt { get; set; }
        public int TypiT { get; set; }
        public int UnitIt { get; set; }
        public Nullable<int> BrcoIt { get; set; }
        public string ItDet { get; set; }
        public bool IsPricing { get; set; }
    }
}
