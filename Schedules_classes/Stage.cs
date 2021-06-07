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

    public partial class Stage
    {
        public Stage()
        {
            this.Schools = new HashSet<School>();
        }
    
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Added_by { get; set; }
        public Nullable<System.DateTime> Added_date { get; set; }
        public string Notes { get; set; }
    
        public virtual ICollection<School> Schools { get; set; }
    }
}
