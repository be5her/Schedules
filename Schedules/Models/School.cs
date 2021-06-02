using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class School
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stage_id { get; set; }

        public int Client_id { get; set; }

        public bool Is_joined { get; set; }

        public int Added_by { get; set; }

        public DateTime Added_date { get; set; }

        public string Notes { get; set; }


    }
}
