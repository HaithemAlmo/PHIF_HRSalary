using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class hdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SalaryId",
                table: "EmployeePremiums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePremiums_SalaryId",
                table: "EmployeePremiums",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePremiums_Salaries_SalaryId",
                table: "EmployeePremiums",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePremiums_Salaries_SalaryId",
                table: "EmployeePremiums");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePremiums_SalaryId",
                table: "EmployeePremiums");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "EmployeePremiums");
        }
    }
}
