using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class tadawelsalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaryInfoId",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "tadawel",
                table: "Salaries",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_SalaryInfoId",
                table: "Salaries",
                column: "SalaryInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_SalaryInfos_SalaryInfoId",
                table: "Salaries",
                column: "SalaryInfoId",
                principalTable: "SalaryInfos",
                principalColumn: "SalaryInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_SalaryInfos_SalaryInfoId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_SalaryInfoId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "SalaryInfoId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "tadawel",
                table: "Salaries");
        }
    }
}
