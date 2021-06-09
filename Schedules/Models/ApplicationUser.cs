using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedules.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string First_name { get; set; }

        public string Last_name { get; set; }

    }
}
