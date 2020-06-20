using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class BillAndExpences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BillServices",
                type: "NUMERIC(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BillServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "BillServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaxPercentage",
                table: "BillServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                table: "Bills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BillNumber",
                table: "Bills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Bills",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PoSoNumber",
                table: "Bills",
                type: "NUMERIC(12,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrBillDate",
                table: "Bills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrDueDate",
                table: "Bills",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BillServices");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BillServices");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "BillServices");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "BillServices");

            migrationBuilder.DropColumn(
                name: "BillDate",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillNumber",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PoSoNumber",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "StrBillDate",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "StrDueDate",
                table: "Bills");
        }
    }
}
