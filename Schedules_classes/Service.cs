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

    public partial class Service
    {
        public Service()
        {
            this.Order_Services = new HashSet<Order_Services>();
        }
    
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        public string Added_by { get; set; }
        public Nullable<System.DateTime> Added_date { get; set; }
    
        public virtual ICollection<Order_Services> Order_Services { get; set; }
    }
}
