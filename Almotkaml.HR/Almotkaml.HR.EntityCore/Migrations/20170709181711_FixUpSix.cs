using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixUpSix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Premiums_PremiumId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Salaries_SalaryId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SalaryPremiums_SalaryPremiumPremiumId_SalaryPremiumSalaryId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryPremiums_Salaries_SalaryId",
                table: "SalaryPremiums");

            migrationBuilder.DropIndex(
                name: "IX_Activities_PremiumId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SalaryId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SalaryPremiumPremiumId_SalaryPremiumSalaryId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "PremiumId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SalaryPremiumPremiumId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SalaryPremiumSalaryId",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "NationalNumber",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CostCenterId",
                table: "Centers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AccountingManualId",
                table: "BankBranches",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInside",
                table: "AdvancePayments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryPremiums_Salaries_SalaryId",
                table: "SalaryPremiums",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryPremiums_Salaries_SalaryId",
                table: "SalaryPremiums");

            migrationBuilder.DropColumn(
                name: "AccountingManualId",
                table: "BankBranches");

            migrationBuilder.DropColumn(
                name: "IsInside",
                table: "AdvancePayments");

            migrationBuilder.AlterColumn<long>(
                name: "NationalNumber",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CostCenterId",
                table: "Centers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PremiumId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalaryId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryPremiumPremiumId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalaryPremiumSalaryId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PremiumId",
                table: "Activities",
                column: "PremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SalaryId",
                table: "Activities",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SalaryPremiumPremiumId_SalaryPremiumSalaryId",
                table: "Activities",
                columns: new[] { "SalaryPremiumPremiumId", "SalaryPremiumSalaryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Premiums_PremiumId",
                table: "Activities",
                column: "PremiumId",
                principalTable: "Premiums",
                principalColumn: "PremiumId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Salaries_SalaryId",
                table: "Activities",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SalaryPremiums_SalaryPremiumPremiumId_SalaryPremiumSalaryId",
                table: "Activities",
                columns: new[] { "SalaryPremiumPremiumId", "SalaryPremiumSalaryId" },
                principalTable: "SalaryPremiums",
                principalColumns: new[] { "PremiumId", "SalaryId" },
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryPremiums_Salaries_SalaryId",
                table: "SalaryPremiums",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
