using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Schedules.Models
{
    [NotMapped]
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Name()
        {
            return First_name + " " + Last_name;
        }
    }
}
