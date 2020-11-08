using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class addColumnsToHistorey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SolidarityFundBondNumber",
                table: "HistorySubsended",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SocialSecurityFundBondNumber",
                table: "HistorySubsended",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Absence",
                table: "HistorySubsended",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Absence",
                table: "HistorySubsended");

            migrationBuilder.AlterColumn<string>(
                name: "SolidarityFundBondNumber",
                table: "HistorySubsended",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "SocialSecurityFundBondNumber",
                table: "HistorySubsended",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
