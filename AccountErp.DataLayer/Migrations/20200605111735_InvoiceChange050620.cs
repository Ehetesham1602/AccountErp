using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class InvoiceChange050620 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "InvoiceServices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "InvoiceServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "InvoiceServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPrice",
                table: "InvoiceServices",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "InvoiceServices");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InvoiceServices");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "InvoiceServices");

            migrationBuilder.DropColumn(
                name: "TaxPrice",
                table: "InvoiceServices");

        }
    }
}
