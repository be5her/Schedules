namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        public int Payment_id { get; set; }

        public int Order_id { get; set; }

        public decimal Amount { get; set; }

        public string Method { get; set; }

        public string Payment_py { get; set; }

        public DateTime Payment_date { get; set; }

        public virtual Order Order { get; set; }
    }
}
