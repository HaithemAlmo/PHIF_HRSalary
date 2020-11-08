using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class SalaryInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialDatas");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Absences");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Absences",
                newName: "Date");

            migrationBuilder.CreateTable(
                name: "SalaryInfos",
                columns: table => new
                {
                    SalaryInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankBranchId = table.Column<int>(nullable: false),
                    BasicSalary = table.Column<decimal>(nullable: false),
                    BondNumber = table.Column<string>(maxLength: 128, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    FinancialNumber = table.Column<string>(maxLength: 128, nullable: true),
                    GuaranteeType = table.Column<int>(nullable: false),
                    SecurityNumber = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryInfos", x => x.SalaryInfoId);
                    table.ForeignKey(
                        name: "FK_SalaryInfos_BankBranches_BankBranchId",
                        column: x => x.BankBranchId,
                        principalTable: "BankBranches",
                        principalColumn: "BankBranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalaryInfos_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryInfos_BankBranchId",
                table: "SalaryInfos",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryInfos_EmployeeId",
                table: "SalaryInfos",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryInfos");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Absences",
                newName: "DateTo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Absences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "FinancialDatas",
                columns: table => new
                {
                    FinancialDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankBranchId = table.Column<int>(nullable: true),
                    BondNumber = table.Column<string>(maxLength: 128, nullable: true),
                    FinancialNumber = table.Column<string>(maxLength: 128, nullable: true),
                    JobInfoId = table.Column<int>(nullable: true),
                    Salary = table.Column<decimal>(nullable: true),
                    SecurityNumber = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialDatas", x => x.FinancialDataId);
                    table.ForeignKey(
                        name: "FK_FinancialDatas_BankBranches_BankBranchId",
                        column: x => x.BankBranchId,
                        principalTable: "BankBranches",
                        principalColumn: "BankBranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialDatas_JobInfos_JobInfoId",
                        column: x => x.JobInfoId,
                        principalTable: "JobInfos",
                        principalColumn: "JobInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialDatas_BankBranchId",
                table: "FinancialDatas",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialDatas_JobInfoId",
                table: "FinancialDatas",
                column: "JobInfoId",
                unique: true);
        }
    }
}
