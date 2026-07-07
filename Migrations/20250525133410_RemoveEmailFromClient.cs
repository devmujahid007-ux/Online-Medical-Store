using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalStore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmailFromClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "ClientName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Clients",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
