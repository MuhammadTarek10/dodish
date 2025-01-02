using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeRestaurantHasContactNumberNotContactName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Restaurants",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Restaurants",
                type: "TEXT",
                maxLength: 50,
                nullable: true);
        }
    }
}
