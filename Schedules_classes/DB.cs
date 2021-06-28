using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Schedules_classes
{
    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_services> Order_services { get; set; }
        public virtual DbSet<Order_workers> Order_workers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Channels)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Added_by);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Clients)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Added_by);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Added_by);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Schools)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Added_by);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Semesters)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Added_by);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Services)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Added_by);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Stages)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Added_by);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Workers)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Added_by);

            modelBuilder.Entity<Channel>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.Client_id);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Schools)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.Client_id);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total_price)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Order>()
                .Property(e => e.Discount)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total_after_discount)
                .HasPrecision(11, 3);

            modelBuilder.Entity<Order>()
                .Property(e => e.Haraj_percentage)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Order>()
                .Property(e => e.Cost)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Order>()
                .Property(e => e.Net_profit)
                .HasPrecision(13, 3);

            modelBuilder.Entity<Order>()
                .Property(e => e.Paid_amount)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Order>()
                .Property(e => e.Remaining_amount)
                .HasPrecision(14, 3);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_services>()
                .Property(e => e.Current_Price)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Order_workers>()
                .Property(e => e.Cost)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Semester>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<Service>()
                .Property(e => e.Price)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Notes)
                .IsFixedLength();

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.Order_workers)
                .WithOptional(e => e.Worker)
                .HasForeignKey(e => e.Order_id);
        }
    }
}
