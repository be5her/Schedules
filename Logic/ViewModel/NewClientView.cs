using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModel
{
    public class NewClientView
    {
        public int School_id { get; set; }

        public string School_name { get; set; }

        public int Stage_id { get; set; }

        public int Client_id { get; set; }

        public string Client_name { get; set; }

        public string Client_phone { get; set; }

        public int Channel_id { get; set; }

        public string Added_by { get; set; }

        public DateTime Added_date { get; set; }
    }
}
