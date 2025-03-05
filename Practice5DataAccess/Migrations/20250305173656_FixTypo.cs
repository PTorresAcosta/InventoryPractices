using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice5DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "Sales",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "Purchases",
                newName: "PurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "Sales",
                newName: "PurchaseId");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "Purchases",
                newName: "SaleId");
        }
    }
}
