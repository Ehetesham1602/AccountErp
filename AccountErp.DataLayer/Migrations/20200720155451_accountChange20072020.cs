using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class accountChange20072020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COA_Account_COA_AccountType_COA_AccountTypeId",
                table: "COA_Account");

            migrationBuilder.DropIndex(
                name: "IX_COA_Account_COA_AccountTypeId",
                table: "COA_Account");

            migrationBuilder.AddColumn<string>(
                name: "AccountCode",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "COA_AccountTypeId",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BankAccounts",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_COA_AccountTypeId",
                table: "BankAccounts",
                column: "COA_AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_COA_AccountType_COA_AccountTypeId",
                table: "BankAccounts",
                column: "COA_AccountTypeId",
                principalTable: "COA_AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_COA_AccountType_COA_AccountTypeId",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_COA_AccountTypeId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "AccountCode",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "COA_AccountTypeId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BankAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_COA_Account_COA_AccountTypeId",
                table: "COA_Account",
                column: "COA_AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_COA_Account_COA_AccountType_COA_AccountTypeId",
                table: "COA_Account",
                column: "COA_AccountTypeId",
                principalTable: "COA_AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
