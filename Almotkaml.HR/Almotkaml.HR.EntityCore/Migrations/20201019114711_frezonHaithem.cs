using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class frezonHaithem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvancePaymentId",
                table: "SalaryPremiums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PremiumId",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsTemporary",
                table: "Premiums",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "IsSubject",
                table: "Premiums",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "IsFrozen",
                table: "Premiums",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "ISAdvanceInside",
                table: "Premiums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdvancePaymentId",
                table: "EmployeePremiums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryPremiums_AdvancePaymentId",
                table: "SalaryPremiums",
                column: "AdvancePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_PremiumId",
                table: "Salaries",
                column: "PremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePremiums_AdvancePaymentId",
                table: "EmployeePremiums",
                column: "AdvancePaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePremiums_AdvancePayments_AdvancePaymentId",
                table: "EmployeePremiums",
                column: "AdvancePaymentId",
                principalTable: "AdvancePayments",
                principalColumn: "AdvancePaymentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Premiums_PremiumId",
                table: "Salaries",
                column: "PremiumId",
                principalTable: "Premiums",
                principalColumn: "PremiumId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryPremiums_AdvancePayments_AdvancePaymentId",
                table: "SalaryPremiums",
                column: "AdvancePaymentId",
                principalTable: "AdvancePayments",
                principalColumn: "AdvancePaymentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePremiums_AdvancePayments_AdvancePaymentId",
                table: "EmployeePremiums");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Premiums_PremiumId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryPremiums_AdvancePayments_AdvancePaymentId",
                table: "SalaryPremiums");

            migrationBuilder.DropIndex(
                name: "IX_SalaryPremiums_AdvancePaymentId",
                table: "SalaryPremiums");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_PremiumId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePremiums_AdvancePaymentId",
                table: "EmployeePremiums");

            migrationBuilder.DropColumn(
                name: "AdvancePaymentId",
                table: "SalaryPremiums");

            migrationBuilder.DropColumn(
                name: "PremiumId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "ISAdvanceInside",
                table: "Premiums");

            migrationBuilder.DropColumn(
                name: "AdvancePaymentId",
                table: "EmployeePremiums");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTemporary",
                table: "Premiums",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "IsSubject",
                table: "Premiums",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "IsFrozen",
                table: "Premiums",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
