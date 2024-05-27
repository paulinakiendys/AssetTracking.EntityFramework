using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetTracking.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class createasset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Brand", "Model", "Price", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, "iPhone", "8", 970, new DateOnly(2021, 10, 13) },
                    { 2, "iPhone", "11", 990, new DateOnly(2021, 10, 12) },
                    { 3, "iPhone", "X", 1245, new DateOnly(2021, 10, 11) },
                    { 4, "Motorola", "Razr", 970, new DateOnly(2021, 10, 10) },
                    { 5, "HP", "Elitebook", 1423, new DateOnly(2021, 7, 13) },
                    { 6, "HP", "Dragonfly", 588, new DateOnly(2021, 7, 12) },
                    { 7, "Asus", "W234", 1200, new DateOnly(2021, 7, 11) },
                    { 8, "Lenovo", "Yoga 730", 835, new DateOnly(2021, 7, 10) },
                    { 9, "Lenovo", "Yoga 530", 1030, new DateOnly(2021, 7, 9) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Model",
                table: "Assets",
                column: "Model",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
