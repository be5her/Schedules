using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Schedules.Models;
using Schedules_classes;

namespace Schedules.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Client { get; set; }

        public DbSet<Channel> Channel { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Order_services> Order_Services { get; set; }

        public DbSet<Order_workers> Order_Workers { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<School> School { get; set; }

        public DbSet<Semester> Semester { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<Stage> Stage { get; set; }

        public DbSet<Worker> Worker { get; set; }

    }
}
