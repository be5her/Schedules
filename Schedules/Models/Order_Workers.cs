using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Order_Workers
    {
        [Key]
        [ForeignKey("Order")]
        public int Order_id { get; set; }

        [Key]
        [ForeignKey("Worker")]
        public int Worker_id { get; set; }

        public string Task_name { get; set; }

        public decimal Cost { get; set; }
    }
}
