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
    
    public partial class Supply
    {
        public int IDMove { get; set; }
        public string DateMove { get; set; }
        public Nullable<int> IDBill { get; set; }
        public int IDSupplier { get; set; }
        public int UserID { get; set; }
        public int StoreID { get; set; }
        public string TypMove { get; set; }
        public int ItemID { get; set; }
        public decimal Amount { get; set; }
        public decimal PurPrice { get; set; }
        public Nullable<int> validity { get; set; }
        public Nullable<int> limitItem { get; set; }
        public string DetailsMove { get; set; }
    }
}