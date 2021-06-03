using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Order_Services
    {
        [Key]
        [ForeignKey("Order")]
        public int Order_id { get; set; }

        [Key]
        [ForeignKey("Service")]
        public int Service_id { get; set; }

        public decimal Current_price { get; set; }

    }
}
