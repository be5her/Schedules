using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Schedules.Models;

namespace Schedules.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Schedules.Models.Order> Order { get; set; }

        public DbSet<Schedules.Models.School> School { get; set; }

        public DbSet<Schedules.Models.Stage> Stage { get; set; }

        public DbSet<Schedules.Models.Client> Client { get; set; }
        
        public DbSet<Schedules.Models.Channel> Channel { get; set; }
        
        public DbSet<Schedules.Models.Payment> Payment { get; set; }
        
        public DbSet<Schedules.Models.Order_Services> Order_Services { get; set; }

        public DbSet<Schedules.Models.Order_Workers> Order_Workers { get; set; }
        
        public DbSet<Schedules.Models.Semester> Semester { get; set; }
       
        public DbSet<Schedules.Models.Service> Service { get; set; }
        
        public DbSet<Schedules.Models.Worker> Worker { get; set; }

    }
}
