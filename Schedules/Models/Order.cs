using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int School_id { get; set; }

        public int Client_id { get; set; }

        public int Semester_id { get; set; }

        public DateTime Order_date { get; set; }

        public int Number_of_teachers { get; set; }

        public decimal Total_price { get; set; }

        public decimal Discount { get; set; }

        public decimal Total_after_discount { get; set; }

        public decimal Haraj_percentage { get; set; }

        public decimal Cost { get; set; }

        public decimal Net_profit { get; set; }

        public decimal Paid_amount { get; set; }

        public decimal Remaining_amount { get; set; }

        public int Added_by { get; set; }

        public string Notes { get; set; }

    }
}
