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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }
    
        public int Id { get; set; }
        public Nullable<decimal> OrderTotal { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime TimeStamp { get; set; }
    
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
