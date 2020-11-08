using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Coach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalayClassification",
                table: "SalaryInfos");

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoachType = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 128, nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachId);
                    table.ForeignKey(
                        name: "FK_Coaches_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_EmployeeId",
                table: "Coaches",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.AddColumn<int>(
                name: "SalayClassification",
                table: "SalaryInfos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
