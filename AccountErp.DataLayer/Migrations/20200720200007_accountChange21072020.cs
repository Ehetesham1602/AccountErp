using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class accountChange21072020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedgerType",
                table: "BankAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "LedgerType",
                table: "BankAccounts");
        }
    }
}
