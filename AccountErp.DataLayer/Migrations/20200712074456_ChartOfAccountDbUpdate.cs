using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class ChartOfAccountDbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COA_AccountMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountMasterName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COA_AccountMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COA_AccountType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COA_AccountMasterId = table.Column<int>(nullable: false),
                    AccountTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COA_AccountType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COA_AccountType_COA_AccountMaster_COA_AccountMasterId",
                        column: x => x.COA_AccountMasterId,
                        principalTable: "COA_AccountMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COA_Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COA_AccountntTypeId = table.Column<int>(nullable: false),
                    AccountName = table.Column<string>(nullable: true),
                    AccountCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    COA_AccountTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COA_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COA_Account_COA_AccountType_COA_AccountTypeId",
                        column: x => x.COA_AccountTypeId,
                        principalTable: "COA_AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COA_Account_COA_AccountTypeId",
                table: "COA_Account",
                column: "COA_AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_COA_AccountType_COA_AccountMasterId",
                table: "COA_AccountType",
                column: "COA_AccountMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COA_Account");

            migrationBuilder.DropTable(
                name: "COA_AccountType");

            migrationBuilder.DropTable(
                name: "COA_AccountMaster");
        }
    }
}
