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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order
    {
        public Order()
        {
            this.Order_services = new HashSet<Order_services>();
            this.Order_workers = new HashSet<Order_workers>();
            this.Payments = new HashSet<Payment>();
        }
    
        [Key]
        public int Order_id { get; set; }

        [ForeignKey("School")]
        public Nullable<int> School_id { get; set; }

        [ForeignKey("Client")]
        public Nullable<int> Client_id { get; set; }

        [ForeignKey("Semester")]
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

        [ForeignKey("AspNetUsers")]
        public string Added_by { get; set; }

        public string Notes { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual School School { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<Order_services> Order_services { get; set; }
        public virtual ICollection<Order_workers> Order_workers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
