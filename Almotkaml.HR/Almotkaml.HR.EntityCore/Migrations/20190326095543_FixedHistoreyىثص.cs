using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixedHistoreyىثص : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "iSClose",
                table: "HistorySubsended",
                newName: "IsClose");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubsendedSalary",
                table: "Salaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsClose",
                table: "HistorySubsended",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ISSubsended",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "NetSalray",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "iSCloseMessage",
                table: "HistorySubsended",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubsendedSalary",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "ISSubsended",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "NetSalray",
                table: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "iSCloseMessage",
                table: "HistorySubsended");

            migrationBuilder.RenameColumn(
                name: "IsClose",
                table: "HistorySubsended",
                newName: "iSClose");

            migrationBuilder.AlterColumn<string>(
                name: "iSClose",
                table: "HistorySubsended",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
