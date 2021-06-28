namespace Schedules_classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_services
    {
        public int Id { get; set; }

        public int? Order_id { get; set; }

        public int? Service_id { get; set; }

        public decimal? Current_Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Service Service { get; set; }
    }
}
