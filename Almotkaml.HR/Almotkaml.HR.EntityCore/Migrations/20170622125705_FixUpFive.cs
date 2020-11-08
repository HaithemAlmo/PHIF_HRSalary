using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixUpFive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BoundNumber",
                table: "Salaries",
                newName: "BondNumber");

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraWorkFixed",
                table: "SalaryInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Sanction",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                table: "Salaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SocialSecurityFundBondNumber",
                table: "Salaries",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolidarityFundBondNumber",
                table: "Salaries",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxBondNumber",
                table: "Salaries",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTemporary",
                table: "Premiums",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CostCenterId",
                table: "Centers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraWorkFixed",
                table: "SalaryInfos");

            migrationBuilder.DropColumn(
                name: "IsSuspended",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "SocialSecurityFundBondNumber",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "SolidarityFundBondNumber",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TaxBondNumber",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "IsTemporary",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "Centers");

            migrationBuilder.RenameColumn(
                name: "BondNumber",
                table: "Salaries",
                newName: "BoundNumber");

            migrationBuilder.AlterColumn<int>(
                name: "Sanction",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
