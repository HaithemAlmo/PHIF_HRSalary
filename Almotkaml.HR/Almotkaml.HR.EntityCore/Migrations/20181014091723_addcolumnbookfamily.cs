using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class addcolumnbookfamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DegreeNote",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookFamilySourceNumber",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationaltyMother",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeNote",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "BookFamilySourceNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationaltyMother",
                table: "Employees");
        }
    }
}
