using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class invoiceBillChangeForSubtotal27072020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "RecurringInvoices",
                type: "NUMERIC(12,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Quotations",
                type: "NUMERIC(12,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Invoices",
                type: "NUMERIC(12,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Bills",
                type: "NUMERIC(12,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "RecurringInvoices");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Bills");
        }
    }
}
