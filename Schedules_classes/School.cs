namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("School")]
    public partial class School
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public School()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int School_id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Stage_id { get; set; }

        public int? Client_id { get; set; }

        public bool Is_joined { get; set; }

        [Required]
        [StringLength(450)]
        public string Added_by { get; set; }

        public DateTime Added_date { get; set; }

        public string Notes { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
