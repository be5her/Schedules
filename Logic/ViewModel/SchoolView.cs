using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModel
{
    public class SchoolView
    {
        public int School_id { get; set; }

        public string School_name { get; set; }

        public int? Stage_id { get; set; }

        public string Stage_name { get; set; }


        public int? Client_id { get; set; }

        public string Client_name { get; set; }

        public string Client_phone { get; set; }

        public string Client_email { get; set; }

        public bool Is_joined { get; set; }

        public int? Channel_id { get; set; }

        public string Channel_name { get; set; }

        public string Added_by { get; set; }

        public string Added_by_name { get; set; }

        public DateTime Added_date { get; set; }

        public string Notes { get; set; }
    }
}
