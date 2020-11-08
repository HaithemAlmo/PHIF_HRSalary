using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class allvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AllValue",
                table: "SalaryPremiums",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IsAdvansePremmium",
                table: "SalaryPremiums",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllValue",
                table: "SalaryPremiums");

            migrationBuilder.DropColumn(
                name: "IsAdvansePremmium",
                table: "SalaryPremiums");
        }
    }
}
