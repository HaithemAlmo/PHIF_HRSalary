using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class addcolumnBalancEHMinTableJobinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CountKids",
                table: "Vacations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VacationBalanceAlhaju",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacationBalanceEmergency",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacationBalanceMarriage",
                table: "JobInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VacationBalanceAlhaju",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "VacationBalanceEmergency",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "VacationBalanceMarriage",
                table: "JobInfos");

            migrationBuilder.AlterColumn<int>(
                name: "CountKids",
                table: "Vacations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
