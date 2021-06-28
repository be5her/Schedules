namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_workers
    {
        public int Id { get; set; }

        public int? Order_id { get; set; }

        public int? Worker_id { get; set; }

        public string Task_name { get; set; }

        public decimal? Cost { get; set; }

        public virtual Order Order { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
