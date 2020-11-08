using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class addColumnsToHistorey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbsenceDays",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalSalary",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SocialSecurityFundBondNumber",
                table: "HistorySubsended",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolidarityFundBondNumber",
                table: "HistorySubsended",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "employeSharea",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "jihad",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "subject",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbsenceDays",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "FinalSalary",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "SocialSecurityFundBondNumber",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "SolidarityFundBondNumber",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "employeSharea",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "jihad",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "subject",
                table: "HistorySubsended");
        }
    }
}
