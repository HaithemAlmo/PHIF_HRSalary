using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class emppremiums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ISAdvancePremmium",
                table: "EmployeePremiums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Valueincpect",
                table: "EmployeePremiums",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISAdvancePremmium",
                table: "EmployeePremiums");

            migrationBuilder.DropColumn(
                name: "Valueincpect",
                table: "EmployeePremiums");
        }
    }
}
