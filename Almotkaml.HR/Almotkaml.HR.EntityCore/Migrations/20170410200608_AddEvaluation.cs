using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EvaluationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    Ratio = table.Column<double>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.EvaluationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EvaluationId",
                table: "Activities",
                column: "EvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Evaluations_EvaluationId",
                table: "Activities",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "EvaluationId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Evaluations_EvaluationId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EvaluationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "Activities");
        }
    }
}
