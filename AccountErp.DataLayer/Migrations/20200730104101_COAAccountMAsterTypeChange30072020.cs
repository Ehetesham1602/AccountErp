using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class COAAccountMAsterTypeChange30072020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TaxPrice",
                table: "RecurringInvoiceServices",
                type: "NUMERIC(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AccountTypeCode",
                table: "COA_AccountType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxPrice",
                table: "RecurringInvoiceServices");

            migrationBuilder.DropColumn(
                name: "AccountTypeCode",
                table: "COA_AccountType");
        }
    }
}
