using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Foooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MonthDate",
                table: "SalaryPremiums",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "DifrancessSetting",
                table: "Salaries",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "VacationBalanceSickNew",
                table: "JobInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthDate",
                table: "SalaryPremiums");

            migrationBuilder.DropColumn(
                name: "DifrancessSetting",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "VacationBalanceSickNew",
                table: "JobInfos");
        }
    }
}
