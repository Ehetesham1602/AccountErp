using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class DecimalPrecisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Vendors",
                type: "NUMERIC(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Payments",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "MemorizedPayments",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Items",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "InvoiceServices",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Invoices",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "Invoices",
                type: "NUMERIC(12,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Invoices",
                type: "NUMERIC(12,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "InvoicePayments",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Customers",
                type: "NUMERIC(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Cheques",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Charges",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "Charges",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Charges",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Bills",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "Bills",
                type: "NUMERIC(12,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Bills",
                type: "NUMERIC(12,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "BillPayments",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Vendors",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "MemorizedPayments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Items",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "InvoiceServices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Invoices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "Invoices",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Invoices",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "InvoicePayments",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Cheques",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Charges",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "Charges",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Charges",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "Bills",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Bills",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "BillPayments",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");
        }
    }
}
