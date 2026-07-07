using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalStore.Migrations
{
    /// <inheritdoc />
    public partial class AddSellOrderTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellOrderId = table.Column<int>(type: "int", nullable: false),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellItems_SellOrders_SellOrderId",
                        column: x => x.SellOrderId,
                        principalTable: "SellOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellItems_SellOrderId",
                table: "SellItems",
                column: "SellOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SellOrders_ClientId",
                table: "SellOrders",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellItems");

            migrationBuilder.DropTable(
                name: "SellOrders");
        }
    }
}
