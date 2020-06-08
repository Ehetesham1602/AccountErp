using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class RemoveUnusedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charges");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "MemorizedPayments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 40, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreditCardId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Tax = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 40, nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charges_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    AmountInWords = table.Column<string>(maxLength: 250, nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Memo = table.Column<string>(maxLength: 500, nullable: false),
                    PayeeAccountId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemorizedPayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "NUMERIC(12,2)", nullable: false),
                    NextPaymentDate = table.Column<DateTime>(nullable: false),
                    PayeeId = table.Column<int>(nullable: false),
                    PaymentIntervalId = table.Column<int>(nullable: false),
                    PaymentTitle = table.Column<string>(nullable: false),
                    ReceiverId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TimesToRepeat = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorizedPayments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charges_CreditCardId",
                table: "Charges",
                column: "CreditCardId");
        }
    }
}
