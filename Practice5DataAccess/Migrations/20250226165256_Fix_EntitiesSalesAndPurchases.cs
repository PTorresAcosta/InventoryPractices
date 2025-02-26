using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice5DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Fix_EntitiesSalesAndPurchases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Sales",
                newName: "SaleDate");

            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Purchases",
                newName: "PurchaseDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Sales",
                newName: "PurchaseDate");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Purchases",
                newName: "SaleDate");
        }
    }
}
