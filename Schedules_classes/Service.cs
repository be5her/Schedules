namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            Order_services = new HashSet<Order_services>();
        }

        [Key]
        public int Service_id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        [ForeignKey("AspNetUser")]
        [StringLength(450)]
        public string Added_by { get; set; }

        public DateTime? Added_date { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_services> Order_services { get; set; }
    }
}
