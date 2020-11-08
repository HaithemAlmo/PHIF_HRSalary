using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class ISPremiumumAdvance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ISAdvancePremmium",
                table: "Premiums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AllValue",
                table: "EmployeePremiums",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IsAdvansePremmium",
                table: "EmployeePremiums",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISAdvancePremmium",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "AllValue",
                table: "EmployeePremiums");

            migrationBuilder.DropColumn(
                name: "IsAdvansePremmium",
                table: "EmployeePremiums");
        }
    }
}
