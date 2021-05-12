using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.BookingService.Migrations
{
    public partial class initMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Discount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    HotelOfferId = table.Column<Guid>(nullable: false),
                    TransportOfferId = table.Column<Guid>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    PaymentId = table.Column<Guid>(nullable: false),
                    CanceledStatus = table.Column<bool>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PaymentId",
                table: "Bookings",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
