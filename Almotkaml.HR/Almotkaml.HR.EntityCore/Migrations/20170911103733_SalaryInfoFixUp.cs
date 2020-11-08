using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class SalaryInfoFixUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileNumber",
                table: "SalaryInfos",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalayClassification",
                table: "SalaryInfos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileNumber",
                table: "SalaryInfos");

            migrationBuilder.DropColumn(
                name: "SalayClassification",
                table: "SalaryInfos");
        }
    }
}
