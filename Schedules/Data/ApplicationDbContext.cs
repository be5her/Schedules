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

        public DbSet<Client> Clients { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Order_Services> Order_Services { get; set; }

        public DbSet<Order_Workers> Order_Workers { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<Worker> Workers { get; set; }

    }
}
