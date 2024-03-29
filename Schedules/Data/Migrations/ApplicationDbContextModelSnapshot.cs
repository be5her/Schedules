﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schedules.Data;

namespace Schedules.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Schedules.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("First_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Schedules_classes.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("First_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Last_name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("AspNetUser");
                });

            modelBuilder.Entity("Schedules_classes.Channel", b =>
                {
                    b.Property<int>("Channel_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Added_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AspNetUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Channel_id");

                    b.HasIndex("AspNetUserId");

                    b.ToTable("Channel");
                });

            modelBuilder.Entity("Schedules_classes.Client", b =>
                {
                    b.Property<int>("Client_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Added_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AspNetUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Channel_id")
                        .HasColumnType("int");

                    b.Property<int?>("Channel_id1")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Client_id");

                    b.HasIndex("AspNetUserId");

                    b.HasIndex("Channel_id1");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Schedules_classes.Order", b =>
                {
                    b.Property<int>("Order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("AspNetUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ClientClient_id")
                        .HasColumnType("int");

                    b.Property<int?>("Client_id")
                        .HasColumnType("int");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Haraj_percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Net_profit")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Number_of_teachers")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Order_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Paid_amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Remaining_amount")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("School_id")
                        .HasColumnType("int");

                    b.Property<int?>("School_id1")
                        .HasColumnType("int");

                    b.Property<int?>("Semester_id")
                        .HasColumnType("int");

                    b.Property<int?>("Semester_id1")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total_after_discount")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Total_price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Order_id");

                    b.HasIndex("AspNetUserId");

                    b.HasIndex("ClientClient_id");

                    b.HasIndex("School_id1");

                    b.HasIndex("Semester_id1");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Schedules_classes.Order_services", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Current_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Order_id")
                        .HasColumnType("int");

                    b.Property<int?>("Order_id1")
                        .HasColumnType("int");

                    b.Property<int?>("Service_id")
                        .HasColumnType("int");

                    b.Property<int?>("Service_id1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Order_id1");

                    b.HasIndex("Service_id1");

                    b.ToTable("Order_services");
                });

            modelBuilder.Entity("Schedules_classes.Order_workers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Order_id")
                        .HasColumnType("int");

                    b.Property<int?>("Order_id1")
                        .HasColumnType("int");

                    b.Property<string>("Task_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Worker_id")
                        .HasColumnType("int");

                    b.Property<int?>("Worker_id1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Order_id1");

                    b.HasIndex("Worker_id1");

                    b.ToTable("Order_workers");
                });

            modelBuilder.Entity("Schedules_classes.Payment", b =>
                {
                    b.Property<int>("Payment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order_id")
                        .HasColumnType("int");

                    b.Property<int?>("Order_id1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Payment_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Payment_id");

                    b.HasIndex("Order_id1");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Schedules_classes.School", b =>
                {
                    b.Property<int>("School_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Added_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AspNetUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ClientClient_id")
                        .HasColumnType("int");

                    b.Property<int?>("Client_id")
                        .HasColumnType("int");

                    b.Property<bool?>("Is_joined")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Stage_id")
                        .HasColumnType("int");

                    b.Property<int?>("Stage_id1")
                        .HasColumnType("int");

                    b.HasKey("School_id");

                    b.HasIndex("AspNetUserId");

                    b.HasIndex("ClientClient_id");

                    b.HasIndex("Stage_id1");

                    b.ToTable("School");
                });

            modelBuilder.Entity("Schedules_classes.Semester", b =>
                {
                    b.Property<int>("Semester_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Added_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AspNetUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<bool?>("Is_active")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Semester_id");

                    b.HasIndex("AspNetUserId");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("Schedules_classes.Service", b =>
                {
                    b.Property<int>("Service_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Added_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AspNetUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Service_id");

                    b.HasIndex("AspNetUserId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Schedules_classes.Stage", b =>
                {
                    b.Property<int>("Stage_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Added_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AspNetUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Stage_id");

                    b.HasIndex("AspNetUserId");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("Schedules_classes.Worker", b =>
                {
                    b.Property<int>("Worker_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("Added_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AspNetUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Worker_id");

                    b.HasIndex("AspNetUserId");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Schedules.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Schedules.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedules.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Schedules.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Schedules_classes.Channel", b =>
                {
                    b.HasOne("Schedules_classes.AspNetUser", "AspNetUser")
                        .WithMany("Channels")
                        .HasForeignKey("AspNetUserId");
                });

            modelBuilder.Entity("Schedules_classes.Client", b =>
                {
                    b.HasOne("Schedules_classes.AspNetUser", "AspNetUser")
                        .WithMany("Clients")
                        .HasForeignKey("AspNetUserId");

                    b.HasOne("Schedules_classes.Channel", "Channel")
                        .WithMany("Clients")
                        .HasForeignKey("Channel_id1");
                });

            modelBuilder.Entity("Schedules_classes.Order", b =>
                {
                    b.HasOne("Schedules_classes.AspNetUser", "AspNetUser")
                        .WithMany("Orders")
                        .HasForeignKey("AspNetUserId");

                    b.HasOne("Schedules_classes.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientClient_id");

                    b.HasOne("Schedules_classes.School", "School")
                        .WithMany("Orders")
                        .HasForeignKey("School_id1");

                    b.HasOne("Schedules_classes.Semester", "Semester")
                        .WithMany("Orders")
                        .HasForeignKey("Semester_id1");
                });

            modelBuilder.Entity("Schedules_classes.Order_services", b =>
                {
                    b.HasOne("Schedules_classes.Order", "Order")
                        .WithMany("Order_services")
                        .HasForeignKey("Order_id1");

                    b.HasOne("Schedules_classes.Service", "Service")
                        .WithMany("Order_services")
                        .HasForeignKey("Service_id1");
                });

            modelBuilder.Entity("Schedules_classes.Order_workers", b =>
                {
                    b.HasOne("Schedules_classes.Order", "Order")
                        .WithMany("Order_workers")
                        .HasForeignKey("Order_id1");

                    b.HasOne("Schedules_classes.Worker", "Worker")
                        .WithMany("Order_workers")
                        .HasForeignKey("Worker_id1");
                });

            modelBuilder.Entity("Schedules_classes.Payment", b =>
                {
                    b.HasOne("Schedules_classes.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("Order_id1");
                });

            modelBuilder.Entity("Schedules_classes.School", b =>
                {
                    b.HasOne("Schedules_classes.AspNetUser", "AspNetUser")
                        .WithMany("Schools")
                        .HasForeignKey("AspNetUserId");

                    b.HasOne("Schedules_classes.Client", "Client")
                        .WithMany("Schools")
                        .HasForeignKey("ClientClient_id");

                    b.HasOne("Schedules_classes.Stage", "Stage")
                        .WithMany("Schools")
                        .HasForeignKey("Stage_id1");
                });

            modelBuilder.Entity("Schedules_classes.Semester", b =>
                {
                    b.HasOne("Schedules_classes.AspNetUser", "AspNetUser")
                        .WithMany("Semesters")
                        .HasForeignKey("AspNetUserId");
                });

            modelBuilder.Entity("Schedules_classes.Service", b =>
                {
                    b.HasOne("Schedules_classes.AspNetUser", "AspNetUser")
                        .WithMany("Services")
                        .HasForeignKey("AspNetUserId");
                });

            modelBuilder.Entity("Schedules_classes.Stage", b =>
                {
                    b.HasOne("Schedules_classes.AspNetUser", "AspNetUser")
                        .WithMany("Stages")
                        .HasForeignKey("AspNetUserId");
                });

            modelBuilder.Entity("Schedules_classes.Worker", b =>
                {
                    b.HasOne("Schedules_classes.AspNetUser", "AspNetUser")
                        .WithMany("Workers")
                        .HasForeignKey("AspNetUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
