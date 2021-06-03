using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        [ForeignKey("Channel")]
        public int Channel_id { get; set; }

        [ForeignKey("AspNetUsers")]
        public int Added_by { get; set; }

        public DateTime Add_date { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        
    }
}
