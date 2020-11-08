using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class SituationResolveJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SituationResolveJobId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SituationResolveJobs",
                columns: table => new
                {
                    SituationResolveJobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Boun = table.Column<int>(nullable: false),
                    BounNow = table.Column<int>(nullable: false),
                    DateDegreeLast = table.Column<DateTime>(nullable: false),
                    DecisionDate = table.Column<DateTime>(nullable: false),
                    DecisionNumber = table.Column<string>(nullable: true),
                    Degree = table.Column<int>(nullable: false),
                    DegreeNow = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituationResolveJobs", x => x.SituationResolveJobId);
                    table.ForeignKey(
                        name: "FK_SituationResolveJobs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SituationResolveJobId",
                table: "Activities",
                column: "SituationResolveJobId");

            migrationBuilder.CreateIndex(
                name: "IX_SituationResolveJobs_EmployeeId",
                table: "SituationResolveJobs",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SituationResolveJobs_SituationResolveJobId",
                table: "Activities",
                column: "SituationResolveJobId",
                principalTable: "SituationResolveJobs",
                principalColumn: "SituationResolveJobId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SituationResolveJobs_SituationResolveJobId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "SituationResolveJobs");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SituationResolveJobId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SituationResolveJobId",
                table: "Activities");
        }
    }
}
