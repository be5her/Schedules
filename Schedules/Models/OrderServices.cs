using Schedules_classes;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schedules.Models
{
    public partial class OrderServices
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public decimal? CurrentPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
