using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Vacation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VacationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    VacationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    DecisionDate = table.Column<DateTime>(nullable: true),
                    DecisionNumber = table.Column<string>(maxLength: 128, nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Place = table.Column<bool>(nullable: false),
                    VacationTypeId = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.VacationId);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacations_VacationTypes_VacationTypeId",
                        column: x => x.VacationTypeId,
                        principalTable: "VacationTypes",
                        principalColumn: "VacationTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_VacationId",
                table: "Activities",
                column: "VacationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeId",
                table: "Vacations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_VacationTypeId",
                table: "Vacations",
                column: "VacationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Vacations_VacationId",
                table: "Activities",
                column: "VacationId",
                principalTable: "Vacations",
                principalColumn: "VacationId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Vacations_VacationId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Activities_VacationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "VacationId",
                table: "Activities");
        }
    }
}
