using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class freeez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SalaryId",
                table: "SalaryInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryInfos_SalaryId",
                table: "SalaryInfos",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryInfos_Salaries_SalaryId",
                table: "SalaryInfos",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryInfos_Salaries_SalaryId",
                table: "SalaryInfos");

            migrationBuilder.DropIndex(
                name: "IX_SalaryInfos_SalaryId",
                table: "SalaryInfos");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "SalaryInfos");
        }
    }
}
