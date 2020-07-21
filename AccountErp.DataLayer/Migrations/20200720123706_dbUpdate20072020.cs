using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class dbUpdate20072020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ItemFor",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemFor",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
