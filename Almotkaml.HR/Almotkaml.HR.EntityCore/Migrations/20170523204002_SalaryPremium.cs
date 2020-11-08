using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class SalaryPremium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaryPremiumPremiumId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalaryPremiumSalaryId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalaryPremiums",
                columns: table => new
                {
                    PremiumId = table.Column<int>(nullable: false),
                    SalaryId = table.Column<long>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryPremiums", x => new { x.PremiumId, x.SalaryId });
                    table.ForeignKey(
                        name: "FK_SalaryPremiums_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SalaryPremiumPremiumId_SalaryPremiumSalaryId",
                table: "Activities",
                columns: new[] { "SalaryPremiumPremiumId", "SalaryPremiumSalaryId" });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryPremiums_SalaryId",
                table: "SalaryPremiums",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SalaryPremiums_SalaryPremiumPremiumId_SalaryPremiumSalaryId",
                table: "Activities",
                columns: new[] { "SalaryPremiumPremiumId", "SalaryPremiumSalaryId" },
                principalTable: "SalaryPremiums",
                principalColumns: new[] { "PremiumId", "SalaryId" },
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SalaryPremiums_SalaryPremiumPremiumId_SalaryPremiumSalaryId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "SalaryPremiums");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SalaryPremiumPremiumId_SalaryPremiumSalaryId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SalaryPremiumPremiumId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SalaryPremiumSalaryId",
                table: "Activities");
        }
    }
}
