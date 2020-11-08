using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class deletecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueNow",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "Vlalueincpect",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "AllValue",
                table: "EmployeePremiums");

            migrationBuilder.DropColumn(
                name: "Valueincpect",
                table: "EmployeePremiums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValueNow",
                table: "Premiums",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Vlalueincpect",
                table: "Premiums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AllValue",
                table: "EmployeePremiums",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Valueincpect",
                table: "EmployeePremiums",
                nullable: false,
                defaultValue: 0);
        }
    }
}
