using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class InvoiceForeignKeyChange09082020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceServices_SalesTaxes_TaxId",
                table: "InvoiceServices");

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "InvoiceServices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceServices_SalesTaxes_TaxId",
                table: "InvoiceServices",
                column: "TaxId",
                principalTable: "SalesTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceServices_SalesTaxes_TaxId",
                table: "InvoiceServices");

            migrationBuilder.AlterColumn<int>(
                name: "TaxId",
                table: "InvoiceServices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceServices_SalesTaxes_TaxId",
                table: "InvoiceServices",
                column: "TaxId",
                principalTable: "SalesTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
