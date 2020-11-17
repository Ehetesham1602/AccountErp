using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class dbupdate13Nov2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ShippingAddress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Addresses",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ShippingAddress");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Addresses");
        }
    }
}
