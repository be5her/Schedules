using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Channel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Added_by { get; set; }

        public DateTime Added_date { get; set; }

    }
}
