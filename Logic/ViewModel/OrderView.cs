using Schedules_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModel
{
    public class OrderView
    {
        public int? Order_id { get; set; }

        public int? Semester_id { get; set; }

        public string Semester_code { get; set; }

        public string Semester_title { get; set; }

        public int? School_id { get; set; }

        public string School_name { get; set; }

        public DateTime Order_date { get; set; }

        public int? Stage_id { get; set; }

        public string Stage_name { get; set; }

        public int? Client_id { get; set; }

        public string Client_name { get; set; }

        public string Client_phone { get; set; }

        public string Client_email { get; set; }

        public bool Is_joined { get; set; }

        public int? Channel_id { get; set; }

        public string Channel_name { get; set; }

        public int? Number_of_teachers { get; set; }

        public List<Order_services> Order_services { get; set; }

        public List<Service> Services { get; set; }

        [NotMapped]
        public List<int> Services_id { get; set; }

        public decimal? Total_price { get; set; }

        public decimal Discount { get; set; }

        public decimal Total_after_discount { get; set; }

        public decimal Haraj_percentage { get; set; }

        public decimal? Cost { get; set; }

        public decimal? Net_profit { get; set; }

        public List<Payment> payments { get; set; }

        public decimal? Paid_amount { get; set; }

        public decimal? Remaining_amount { get; set; }

        public List<Order_workers> Order_workers { get; set; }

        public List<Worker> Workers { get; set; }

        public string Added_by { get; set; }

        public string Added_by_name { get; set; }

        public string Notes { get; set; }
    }
}
