using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class staffingAmel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffingClassificationId",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffingClassificationId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SituationEssential",
                table: "CurrentSituations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StaffingClassifications",
                columns: table => new
                {
                    StaffingClassificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StaffingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffingClassifications", x => x.StaffingClassificationId);
                    table.ForeignKey(
                        name: "FK_StaffingClassifications_Staffings_StaffingId",
                        column: x => x.StaffingId,
                        principalTable: "Staffings",
                        principalColumn: "StaffingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_StaffingClassificationId",
                table: "JobInfos",
                column: "StaffingClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StaffingClassificationId",
                table: "Employees",
                column: "StaffingClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffingClassifications_StaffingId",
                table: "StaffingClassifications",
                column: "StaffingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_StaffingClassifications_StaffingClassificationId",
                table: "Employees",
                column: "StaffingClassificationId",
                principalTable: "StaffingClassifications",
                principalColumn: "StaffingClassificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobInfos_StaffingClassifications_StaffingClassificationId",
                table: "JobInfos",
                column: "StaffingClassificationId",
                principalTable: "StaffingClassifications",
                principalColumn: "StaffingClassificationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_StaffingClassifications_StaffingClassificationId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_JobInfos_StaffingClassifications_StaffingClassificationId",
                table: "JobInfos");

            migrationBuilder.DropTable(
                name: "StaffingClassifications");

            migrationBuilder.DropIndex(
                name: "IX_JobInfos_StaffingClassificationId",
                table: "JobInfos");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StaffingClassificationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StaffingClassificationId",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "StaffingClassificationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SituationEssential",
                table: "CurrentSituations");
        }
    }
}
