using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class RecurringInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecurringInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    RecInvoiceNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Tax = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    StrRecInvoiceDate = table.Column<string>(nullable: true),
                    RecInvoiceDate = table.Column<DateTime>(nullable: false),
                    StrRecDueDate = table.Column<string>(nullable: true),
                    RecDueDate = table.Column<DateTime>(nullable: false),
                    PoSoNumber = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringInvoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurringInvoiceAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecInvoiceId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    OriginalFileName = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringInvoiceAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringInvoiceAttachments_RecurringInvoices_RecInvoiceId",
                        column: x => x.RecInvoiceId,
                        principalTable: "RecurringInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurringInvoiceServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecInvoiceId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Price = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    TaxId = table.Column<int>(nullable: false),
                    TaxPercentage = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringInvoiceServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringInvoiceServices_RecurringInvoices_RecInvoiceId",
                        column: x => x.RecInvoiceId,
                        principalTable: "RecurringInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurringInvoiceServices_Items_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoiceAttachments_RecInvoiceId",
                table: "RecurringInvoiceAttachments",
                column: "RecInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoices_CustomerId",
                table: "RecurringInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoiceServices_RecInvoiceId",
                table: "RecurringInvoiceServices",
                column: "RecInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringInvoiceServices_ServiceId",
                table: "RecurringInvoiceServices",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecurringInvoiceAttachments");

            migrationBuilder.DropTable(
                name: "RecurringInvoiceServices");

            migrationBuilder.DropTable(
                name: "RecurringInvoices");
        }
    }
}
