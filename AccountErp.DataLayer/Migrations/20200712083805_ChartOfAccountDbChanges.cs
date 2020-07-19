using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class ChartOfAccountDbChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COA_Account_COA_AccountType_COA_AccountTypeId",
                table: "COA_Account");

            migrationBuilder.DropColumn(
                name: "COA_AccountntTypeId",
                table: "COA_Account");

            migrationBuilder.AlterColumn<int>(
                name: "COA_AccountTypeId",
                table: "COA_Account",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_COA_Account_COA_AccountType_COA_AccountTypeId",
                table: "COA_Account",
                column: "COA_AccountTypeId",
                principalTable: "COA_AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COA_Account_COA_AccountType_COA_AccountTypeId",
                table: "COA_Account");

            migrationBuilder.AlterColumn<int>(
                name: "COA_AccountTypeId",
                table: "COA_Account",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "COA_AccountntTypeId",
                table: "COA_Account",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_COA_Account_COA_AccountType_COA_AccountTypeId",
                table: "COA_Account",
                column: "COA_AccountTypeId",
                principalTable: "COA_AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
