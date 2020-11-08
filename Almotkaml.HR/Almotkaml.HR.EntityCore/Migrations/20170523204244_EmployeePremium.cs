using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class EmployeePremium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeePremiumEmployeeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeePremiumPremiumId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeePremiums",
                columns: table => new
                {
                    PremiumId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePremiums", x => new { x.PremiumId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeePremiums_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePremiums_Premiums_PremiumId",
                        column: x => x.PremiumId,
                        principalTable: "Premiums",
                        principalColumn: "PremiumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EmployeePremiumPremiumId_EmployeePremiumEmployeeId",
                table: "Activities",
                columns: new[] { "EmployeePremiumPremiumId", "EmployeePremiumEmployeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePremiums_EmployeeId",
                table: "EmployeePremiums",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_EmployeePremiums_EmployeePremiumPremiumId_EmployeePremiumEmployeeId",
                table: "Activities",
                columns: new[] { "EmployeePremiumPremiumId", "EmployeePremiumEmployeeId" },
                principalTable: "EmployeePremiums",
                principalColumns: new[] { "PremiumId", "EmployeeId" },
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_EmployeePremiums_EmployeePremiumPremiumId_EmployeePremiumEmployeeId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "EmployeePremiums");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EmployeePremiumPremiumId_EmployeePremiumEmployeeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EmployeePremiumEmployeeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EmployeePremiumPremiumId",
                table: "Activities");
        }
    }
}
