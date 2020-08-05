using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class LineAmountChange05082020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LineAmount",
                table: "RecurringInvoiceServices",
                type: "NUMERIC(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LineAmount",
                table: "QuotationServices",
                type: "NUMERIC(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LineAmount",
                table: "InvoiceServices",
                type: "NUMERIC(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LineAmount",
                table: "BillServices",
                type: "NUMERIC(12,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineAmount",
                table: "RecurringInvoiceServices");

            migrationBuilder.DropColumn(
                name: "LineAmount",
                table: "QuotationServices");

            migrationBuilder.DropColumn(
                name: "LineAmount",
                table: "InvoiceServices");

            migrationBuilder.DropColumn(
                name: "LineAmount",
                table: "BillServices");
        }
    }
}
