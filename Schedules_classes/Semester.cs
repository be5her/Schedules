namespace Schedules_classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Semester")]
    public partial class Semester : IComparable<Semester>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semester()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Semester_id { get; set; }

        [Required]
        [StringLength(6)]
        public string Code { get; set; }

        public string Title { get; set; }

        public bool Is_active { get; set; }

        [ForeignKey("AspNetUser")]
        [StringLength(450)]
        public string Added_by { get; set; }

        public DateTime Added_date { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public int CompareTo(Semester s)
        {
            return Int32.Parse(s.Code.Replace("-", "")).CompareTo(Int32.Parse(this.Code.Replace("-", "")));
        }
    }
}
