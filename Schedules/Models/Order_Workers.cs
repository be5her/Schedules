using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Order_Workers
    {
        public int Order_id { get; set; }

        public int Worker_id { get; set; }

        public string Task_name { get; set; }

        public decimal Cost { get; set; }
    }
}
