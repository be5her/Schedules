using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int Order_id { get; set; }

        public decimal Amount { get; set; }

        public string Method { get; set; }

        public DateTime Payment_date { get; set; }

    }
}
