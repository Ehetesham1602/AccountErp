using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class updatedatabase100620 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaxPercentage",
                table: "QuotationServices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxPercentage",
                table: "InvoiceServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "QuotationServices");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "InvoiceServices");
        }
    }
}
