using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedules.Data.Migrations
{
    public partial class addingclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "First_name",
            //    table: "AspNetUsers",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Last_name",
            //    table: "AspNetUsers",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetUser",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    First_name = table.Column<string>(maxLength: 100, nullable: true),
                    Last_name = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Channel_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Added_date = table.Column<DateTime>(nullable: true),
                    Added_by = table.Column<string>(maxLength: 450, nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Channel_id);
                    table.ForeignKey(
                        name: "FK_Channel_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Semester_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 6, nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Is_active = table.Column<bool>(nullable: true),
                    Added_by = table.Column<string>(maxLength: 450, nullable: true),
                    Added_date = table.Column<DateTime>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Semester_id);
                    table.ForeignKey(
                        name: "FK_Semester_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Service_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: true),
                    Added_by = table.Column<string>(maxLength: 450, nullable: true),
                    Added_date = table.Column<DateTime>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Service_id);
                    table.ForeignKey(
                        name: "FK_Service_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    Stage_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Added_by = table.Column<string>(maxLength: 450, nullable: true),
                    Added_date = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Stage_id);
                    table.ForeignKey(
                        name: "FK_Stage_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Worker_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 10, nullable: true),
                    Added_by = table.Column<string>(maxLength: 450, nullable: true),
                    Added_date = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(maxLength: 10, nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Worker_id);
                    table.ForeignKey(
                        name: "FK_Worker_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Client_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Added_by = table.Column<string>(maxLength: 450, nullable: true),
                    Added_date = table.Column<DateTime>(nullable: true),
                    Channel_id = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true),
                    Channel_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Client_id);
                    table.ForeignKey(
                        name: "FK_Client_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Channel_Channel_id1",
                        column: x => x.Channel_id1,
                        principalTable: "Channel",
                        principalColumn: "Channel_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    School_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Stage_id = table.Column<int>(nullable: true),
                    Client_id = table.Column<int>(nullable: true),
                    Is_joined = table.Column<bool>(nullable: true),
                    Added_by = table.Column<string>(maxLength: 450, nullable: true),
                    Added_date = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true),
                    ClientClient_id = table.Column<int>(nullable: true),
                    Stage_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.School_id);
                    table.ForeignKey(
                        name: "FK_School_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Client_ClientClient_id",
                        column: x => x.ClientClient_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_School_Stage_Stage_id1",
                        column: x => x.Stage_id1,
                        principalTable: "Stage",
                        principalColumn: "Stage_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School_id = table.Column<int>(nullable: true),
                    Client_id = table.Column<int>(nullable: true),
                    Semester_id = table.Column<int>(nullable: true),
                    Order_date = table.Column<DateTime>(nullable: true),
                    Number_of_teachers = table.Column<int>(nullable: true),
                    Total_price = table.Column<decimal>(nullable: true),
                    Discount = table.Column<decimal>(nullable: true),
                    Total_after_discount = table.Column<decimal>(nullable: true),
                    Haraj_percentage = table.Column<decimal>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    Net_profit = table.Column<decimal>(nullable: true),
                    Paid_amount = table.Column<decimal>(nullable: true),
                    Remaining_amount = table.Column<decimal>(nullable: true),
                    Added_by = table.Column<string>(maxLength: 450, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true),
                    ClientClient_id = table.Column<int>(nullable: true),
                    School_id1 = table.Column<int>(nullable: true),
                    Semester_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientClient_id",
                        column: x => x.ClientClient_id,
                        principalTable: "Client",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_School_School_id1",
                        column: x => x.School_id1,
                        principalTable: "School",
                        principalColumn: "School_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Semester_Semester_id1",
                        column: x => x.Semester_id1,
                        principalTable: "Semester",
                        principalColumn: "Semester_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_id = table.Column<int>(nullable: true),
                    Service_id = table.Column<int>(nullable: true),
                    Current_Price = table.Column<decimal>(nullable: true),
                    Order_id1 = table.Column<int>(nullable: true),
                    Service_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_services_Order_Order_id1",
                        column: x => x.Order_id1,
                        principalTable: "Order",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_services_Service_Service_id1",
                        column: x => x.Service_id1,
                        principalTable: "Service",
                        principalColumn: "Service_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_workers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_id = table.Column<int>(nullable: true),
                    Worker_id = table.Column<int>(nullable: true),
                    Task_name = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    Order_id1 = table.Column<int>(nullable: true),
                    Worker_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_workers_Order_Order_id1",
                        column: x => x.Order_id1,
                        principalTable: "Order",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_workers_Worker_Worker_id1",
                        column: x => x.Worker_id1,
                        principalTable: "Worker",
                        principalColumn: "Worker_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Payment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_id = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Method = table.Column<string>(nullable: true),
                    Payment_date = table.Column<DateTime>(nullable: true),
                    Order_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Payment_id);
                    table.ForeignKey(
                        name: "FK_Payment_Order_Order_id1",
                        column: x => x.Order_id1,
                        principalTable: "Order",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channel_AspNetUserId",
                table: "Channel",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_AspNetUserId",
                table: "Client",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Channel_id1",
                table: "Client",
                column: "Channel_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AspNetUserId",
                table: "Order",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientClient_id",
                table: "Order",
                column: "ClientClient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_School_id1",
                table: "Order",
                column: "School_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Semester_id1",
                table: "Order",
                column: "Semester_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_services_Order_id1",
                table: "Order_services",
                column: "Order_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_services_Service_id1",
                table: "Order_services",
                column: "Service_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_workers_Order_id1",
                table: "Order_workers",
                column: "Order_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_workers_Worker_id1",
                table: "Order_workers",
                column: "Worker_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Order_id1",
                table: "Payment",
                column: "Order_id1");

            migrationBuilder.CreateIndex(
                name: "IX_School_AspNetUserId",
                table: "School",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_School_ClientClient_id",
                table: "School",
                column: "ClientClient_id");

            migrationBuilder.CreateIndex(
                name: "IX_School_Stage_id1",
                table: "School",
                column: "Stage_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_AspNetUserId",
                table: "Semester",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_AspNetUserId",
                table: "Service",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_AspNetUserId",
                table: "Stage",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_AspNetUserId",
                table: "Worker",
                column: "AspNetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_services");

            migrationBuilder.DropTable(
                name: "Order_workers");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "AspNetUser");

            migrationBuilder.DropColumn(
                name: "First_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Last_name",
                table: "AspNetUsers");
        }
    }
}
