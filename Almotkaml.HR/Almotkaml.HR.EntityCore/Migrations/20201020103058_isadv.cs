using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class isadv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ISAdvancePremmium",
                table: "SalaryPremiums",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISAdvancePremmium",
                table: "SalaryPremiums");
        }
    }
}
