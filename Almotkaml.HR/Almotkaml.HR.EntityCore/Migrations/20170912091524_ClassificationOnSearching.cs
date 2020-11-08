using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class ClassificationOnSearching : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassificationOnSearchingId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassificationOnSearchings",
                columns: table => new
                {
                    ClassificationOnSearchingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationOnSearchings", x => x.ClassificationOnSearchingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_ClassificationOnSearchingId",
                table: "JobInfos",
                column: "ClassificationOnSearchingId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClassificationOnSearchingId",
                table: "Employees",
                column: "ClassificationOnSearchingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClassificationOnSearchings_ClassificationOnSearchingId",
                table: "Employees",
                column: "ClassificationOnSearchingId",
                principalTable: "ClassificationOnSearchings",
                principalColumn: "ClassificationOnSearchingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobInfos_ClassificationOnSearchings_ClassificationOnSearchingId",
                table: "JobInfos",
                column: "ClassificationOnSearchingId",
                principalTable: "ClassificationOnSearchings",
                principalColumn: "ClassificationOnSearchingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClassificationOnSearchings_ClassificationOnSearchingId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_JobInfos_ClassificationOnSearchings_ClassificationOnSearchingId",
                table: "JobInfos");

            migrationBuilder.DropTable(
                name: "ClassificationOnSearchings");

            migrationBuilder.DropIndex(
                name: "IX_JobInfos_ClassificationOnSearchingId",
                table: "JobInfos");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ClassificationOnSearchingId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClassificationOnSearchingId",
                table: "Employees");
        }
    }
}
