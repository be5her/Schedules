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
    
    public partial class Worker
    {
        public Worker()
        {
            this.Order_Workers = new HashSet<Order_Workers>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Added_by { get; set; }
        public Nullable<System.DateTime> Added_date { get; set; }
    
        public virtual ICollection<Order_Workers> Order_Workers { get; set; }
    }
}