using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Restaurants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Restaurants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Restaurants",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Restaurants");
        }
    }
}
