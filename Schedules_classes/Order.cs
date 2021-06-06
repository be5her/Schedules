//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    
    public class Order
    {
        public Order()
        {
            this.Order_Services = new HashSet<Order_Services>();
            this.Order_Workers = new HashSet<Order_Workers>();
            this.Payments = new HashSet<Payment>();
        }
    
        public int Id { get; set; }
        public Nullable<int> School_id { get; set; }
        public Nullable<int> Client_id { get; set; }
        public Nullable<int> Semester_id { get; set; }
        public Nullable<System.DateTime> Order_date { get; set; }
        public Nullable<int> Number_of_teachers { get; set; }
        public Nullable<decimal> Total_price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Total_after_discount { get; set; }
        public Nullable<decimal> Haraj_percentage { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Net_profit { get; set; }
        public Nullable<decimal> Paid_amount { get; set; }
        public Nullable<decimal> Remaining_amount { get; set; }
        public string Notes { get; set; }
        public string Added_by { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual School School { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<Order_Services> Order_Services { get; set; }
        public virtual ICollection<Order_Workers> Order_Workers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
