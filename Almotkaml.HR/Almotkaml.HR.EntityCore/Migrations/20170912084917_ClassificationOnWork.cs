using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class ClassificationOnWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassificationOnSearchingId",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationOnWorkId",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationOnWorkId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassificationOnWorks",
                columns: table => new
                {
                    ClassificationOnWorkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationOnWorks", x => x.ClassificationOnWorkId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_ClassificationOnWorkId",
                table: "JobInfos",
                column: "ClassificationOnWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClassificationOnWorkId",
                table: "Employees",
                column: "ClassificationOnWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClassificationOnWorks_ClassificationOnWorkId",
                table: "Employees",
                column: "ClassificationOnWorkId",
                principalTable: "ClassificationOnWorks",
                principalColumn: "ClassificationOnWorkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobInfos_ClassificationOnWorks_ClassificationOnWorkId",
                table: "JobInfos",
                column: "ClassificationOnWorkId",
                principalTable: "ClassificationOnWorks",
                principalColumn: "ClassificationOnWorkId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClassificationOnWorks_ClassificationOnWorkId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_JobInfos_ClassificationOnWorks_ClassificationOnWorkId",
                table: "JobInfos");

            migrationBuilder.DropTable(
                name: "ClassificationOnWorks");

            migrationBuilder.DropIndex(
                name: "IX_JobInfos_ClassificationOnWorkId",
                table: "JobInfos");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ClassificationOnWorkId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClassificationOnSearchingId",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "ClassificationOnWorkId",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "ClassificationOnWorkId",
                table: "Employees");
        }
    }
}
