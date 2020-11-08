using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Absence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbsenceId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    AbsenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbsenceType = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.AbsenceId);
                    table.ForeignKey(
                        name: "FK_Absences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AbsenceId",
                table: "Activities",
                column: "AbsenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EmployeeId",
                table: "Absences",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Absences_AbsenceId",
                table: "Activities",
                column: "AbsenceId",
                principalTable: "Absences",
                principalColumn: "AbsenceId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Absences_AbsenceId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AbsenceId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AbsenceId",
                table: "Activities");
        }
    }
}
