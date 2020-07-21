using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class shippingAddressupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "ShippingAddress",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "ShippingAddress",
                newName: "AddressLine1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "ShippingAddress",
                newName: "StreetNumber");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "ShippingAddress",
                newName: "StreetName");
        }
    }
}
