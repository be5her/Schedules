using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("School")]
        public int School_id { get; set; }

        [ForeignKey("Client")]
        public int Client_id { get; set; }

        [ForeignKey("Semester")]
        public int Semester_id { get; set; }

        public DateTime Order_date { get; set; }

        [Required]
        public int Number_of_teachers { get; set; }

        public decimal Total_price { get; set; }

        public decimal Discount { get; set; }

        public decimal Total_after_discount { get; set; }

        public decimal Haraj_percentage { get; set; }

        public decimal Cost { get; set; }

        public decimal Net_profit { get; set; }

        public decimal Paid_amount { get; set; }

        public decimal Remaining_amount { get; set; }

        [ForeignKey("AspNetUsers")]
        public int Added_by { get; set; }

        public string Notes { get; set; }

    }
}
