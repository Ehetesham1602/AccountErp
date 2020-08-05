using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class LineAmountSubTotalChange05082020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LineAmountSubTotal",
                table: "RecurringInvoices",
                type: "NUMERIC(12,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LineAmountSubTotal",
                table: "Quotations",
                type: "NUMERIC(12,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LineAmountSubTotal",
                table: "Invoices",
                type: "NUMERIC(12,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LineAmountSubTotal",
                table: "Bills",
                type: "NUMERIC(12,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineAmountSubTotal",
                table: "RecurringInvoices");

            migrationBuilder.DropColumn(
                name: "LineAmountSubTotal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "LineAmountSubTotal",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LineAmountSubTotal",
                table: "Bills");
        }
    }
}
