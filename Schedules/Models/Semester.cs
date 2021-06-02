using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Semester
    {

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public bool Is_active { get; set; }

        public int Added_by { get; set; }

        public DateTime Added_date { get; set; }

    }
}
