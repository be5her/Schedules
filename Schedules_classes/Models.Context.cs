﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schedules_classes
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Client> Clients { get; set; }
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
