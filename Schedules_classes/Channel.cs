namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Channel")]
    public partial class Channel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Channel()
        {
            Clients = new HashSet<Client>();
        }

        [Key]
        public int Channel_id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public DateTime? Added_date { get; set; }

        [ForeignKey("AspNetUser")]
        [StringLength(450)]
        public string Added_by { get; set; }

        [NotMapped]
        public string Added_by_name { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
