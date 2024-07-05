using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pricing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestProductPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceProducts",
                table: "PriceProducts");

            migrationBuilder.DropIndex(
                name: "IX_PriceProducts_ProductId",
                table: "PriceProducts");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PriceProducts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "PriceProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceProducts",
                table: "PriceProducts",
                columns: new[] { "ProductId", "DateCreated" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceProducts_ProductId1",
                table: "PriceProducts",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceProducts_Products_ProductId1",
                table: "PriceProducts",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceProducts_Products_ProductId1",
                table: "PriceProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceProducts",
                table: "PriceProducts");

            migrationBuilder.DropIndex(
                name: "IX_PriceProducts_ProductId1",
                table: "PriceProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PriceProducts");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "PriceProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceProducts",
                table: "PriceProducts",
                columns: new[] { "DataCreate", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceProducts_ProductId",
                table: "PriceProducts",
                column: "ProductId");
        }
    }
}
