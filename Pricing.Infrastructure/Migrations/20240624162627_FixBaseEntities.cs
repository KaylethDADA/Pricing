using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pricing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCreate",
                table: "PriceProducts");

            migrationBuilder.RenameColumn(
                name: "DataCreate",
                table: "Users",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DataCreate",
                table: "Shops",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DataCreate",
                table: "Products",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DataCreate",
                table: "ProductCategory",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DataCreate",
                table: "Cities",
                newName: "DateCreated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Users",
                newName: "DataCreate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Shops",
                newName: "DataCreate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Products",
                newName: "DataCreate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "ProductCategory",
                newName: "DataCreate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Cities",
                newName: "DataCreate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCreate",
                table: "PriceProducts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
