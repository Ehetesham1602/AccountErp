using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class BillQuotationTaxForeignKeyChange09082020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillServices_SalesTaxes_TaxId",
                table: "BillServices");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationServices_SalesTaxes_TaxId",
                table: "QuotationServices");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringInvoiceServices_SalesTaxes_TaxId",
                table: "RecurringInvoiceServices");

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "RecurringInvoiceServices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "QuotationServices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "BillServices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BillServices_SalesTaxes_TaxId",
                table: "BillServices",
                column: "TaxId",
                principalTable: "SalesTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationServices_SalesTaxes_TaxId",
                table: "QuotationServices",
                column: "TaxId",
                principalTable: "SalesTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringInvoiceServices_SalesTaxes_TaxId",
                table: "RecurringInvoiceServices",
                column: "TaxId",
                principalTable: "SalesTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillServices_SalesTaxes_TaxId",
                table: "BillServices");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationServices_SalesTaxes_TaxId",
                table: "QuotationServices");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringInvoiceServices_SalesTaxes_TaxId",
                table: "RecurringInvoiceServices");

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "RecurringInvoiceServices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "QuotationServices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "BillServices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillServices_SalesTaxes_TaxId",
                table: "BillServices",
                column: "TaxId",
                principalTable: "SalesTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationServices_SalesTaxes_TaxId",
                table: "QuotationServices",
                column: "TaxId",
                principalTable: "SalesTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringInvoiceServices_SalesTaxes_TaxId",
                table: "RecurringInvoiceServices",
                column: "TaxId",
                principalTable: "SalesTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
