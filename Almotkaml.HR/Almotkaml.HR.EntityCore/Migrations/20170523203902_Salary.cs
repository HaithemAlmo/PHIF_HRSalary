using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Salary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SalaryId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbsenceDays = table.Column<int>(nullable: false),
                    AdvancePremium = table.Column<decimal>(nullable: false),
                    BankBranchId = table.Column<int>(nullable: false),
                    BasicSalary = table.Column<decimal>(nullable: false),
                    BoundNumber = table.Column<string>(maxLength: 128, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ExtraWorkHoures = table.Column<decimal>(nullable: false),
                    ExtraWorkVacationHoures = table.Column<decimal>(nullable: false),
                    JobNumber = table.Column<string>(maxLength: 128, nullable: false),
                    Month = table.Column<int>(nullable: false),
                    PrepaidSalary = table.Column<decimal>(nullable: false),
                    Sanction = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_Salaries_BankBranches_BankBranchId",
                        column: x => x.BankBranchId,
                        principalTable: "BankBranches",
                        principalColumn: "BankBranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SalaryId",
                table: "Activities",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_BankBranchId",
                table: "Salaries",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Salaries_SalaryId",
                table: "Activities",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Salaries_SalaryId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SalaryId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "Activities");
        }
    }
}
