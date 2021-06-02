using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int Order_id { get; set; }

        public decimal Amount { get; set; }

        public string Method { get; set; }

        public DateTime Payment_date { get; set; }

    }
}
