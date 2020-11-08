using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Divisions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DivisionId",
                table: "Activities",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_DepartmentId",
                table: "Divisions",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Divisions_DivisionId",
                table: "Activities",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Divisions_DivisionId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DivisionId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Activities");
        }
    }
}
