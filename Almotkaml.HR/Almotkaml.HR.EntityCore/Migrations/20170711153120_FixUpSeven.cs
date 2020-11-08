using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixUpSeven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdvancePremium",
                table: "Salaries",
                newName: "WithoutPay");

            migrationBuilder.AddColumn<decimal>(
                name: "AdvancePremiumInside",
                table: "Salaries",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AdvancePremiumOutside",
                table: "Salaries",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvancePremiumInside",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "AdvancePremiumOutside",
                table: "Salaries");

            migrationBuilder.RenameColumn(
                name: "WithoutPay",
                table: "Salaries",
                newName: "AdvancePremium");
        }
    }
}
