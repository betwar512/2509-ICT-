//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantUnitTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public short Quantity { get; set; }
        public System.DateTime Timestamp { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal total()
        {
            return Quantity * UnitPrice;
        }
    
        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}
