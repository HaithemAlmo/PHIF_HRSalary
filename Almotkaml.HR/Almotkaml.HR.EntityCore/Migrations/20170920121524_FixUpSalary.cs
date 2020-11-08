using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixUpSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExtraWorkFixed",
                table: "SalaryInfos",
                newName: "ExtraValue");

            migrationBuilder.RenameColumn(
                name: "ExtraWorkFixed",
                table: "Salaries",
                newName: "ExtraValue");

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraGeneralValue",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraGeneralValue",
                table: "SalaryInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraGeneralValue",
                table: "Salaries",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FileNumber",
                table: "Salaries",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraGeneralValue",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraGeneralValue",
                table: "SalaryInfos");

            migrationBuilder.DropColumn(
                name: "ExtraGeneralValue",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "FileNumber",
                table: "Salaries");

            migrationBuilder.RenameColumn(
                name: "ExtraValue",
                table: "SalaryInfos",
                newName: "ExtraWorkFixed");

            migrationBuilder.RenameColumn(
                name: "ExtraValue",
                table: "Salaries",
                newName: "ExtraWorkFixed");
        }
    }
}
