using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pricing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _0324332134254634fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceProducts_Products_ProductId1",
                table: "PriceProducts");

            migrationBuilder.DropIndex(
                name: "IX_PriceProducts_ProductId1",
                table: "PriceProducts");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "PriceProducts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PriceProducts",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PriceProducts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "PriceProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
