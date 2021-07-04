namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_services = new HashSet<Order_services>();
            Order_workers = new HashSet<Order_workers>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int Order_id { get; set; }

        [ForeignKey("School")]
        public int? School_id { get; set; }

        [ForeignKey("Client")]
        public int? Client_id { get; set; }

        [ForeignKey("Semester")]
        public int? Semester_id { get; set; }

        public DateTime? Order_date { get; set; }

        public int? Number_of_teachers { get; set; }

        public decimal? Total_price { get; set; }

        public decimal? Discount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Total_after_discount { get; set; }

        public decimal? Haraj_percentage { get; set; }

        public decimal? Cost { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Net_profit { get; set; }

        public decimal? Paid_amount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Remaining_amount { get; set; }

        [ForeignKey("AspNetUser")]
        [StringLength(450)]
        public string Added_by { get; set; }

        public string Notes { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Client Client { get; set; }

        public virtual School School { get; set; }

        public virtual Semester Semester { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_services> Order_services { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_workers> Order_workers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
