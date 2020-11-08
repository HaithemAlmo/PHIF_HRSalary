using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class shearedSalaryPremium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_CreatedBy",
                table: "SalaryPremiums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateCreated",
                table: "SalaryPremiums",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateModified",
                table: "SalaryPremiums",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "_ModifiedBy",
                table: "SalaryPremiums",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "SalaryPremiums");

            migrationBuilder.DropColumn(
                name: "_DateCreated",
                table: "SalaryPremiums");

            migrationBuilder.DropColumn(
                name: "_DateModified",
                table: "SalaryPremiums");

            migrationBuilder.DropColumn(
                name: "_ModifiedBy",
                table: "SalaryPremiums");
        }
    }
}
