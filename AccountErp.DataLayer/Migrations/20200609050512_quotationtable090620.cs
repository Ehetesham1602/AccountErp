using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class quotationtable090620 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TaxPrice",
                table: "InvoiceServices",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "InvoiceServices",
                type: "NUMERIC(12,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PoSoNumber",
                table: "Invoices",
                type: "NUMERIC(12,2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    QuotationNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Tax = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    StrQuotationDate = table.Column<string>(nullable: true),
                    QuotationDate = table.Column<DateTime>(nullable: false),
                    StrExpireDate = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    PoSoNumber = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuotationId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    OriginalFileName = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationAttachments_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuotationId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Price = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxId = table.Column<int>(nullable: false),
                    TaxPrice = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationServices_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationServices_Items_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuotationAttachments_QuotationId",
                table: "QuotationAttachments",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationServices_QuotationId",
                table: "QuotationServices",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationServices_ServiceId",
                table: "QuotationServices",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotationAttachments");

            migrationBuilder.DropTable(
                name: "QuotationServices");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxPrice",
                table: "InvoiceServices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "InvoiceServices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PoSoNumber",
                table: "Invoices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,2)",
                oldNullable: true);
        }
    }
}
