using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddQualificationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualificationTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QualificationTypes",
                columns: table => new
                {
                    QualificationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationTypes", x => x.QualificationTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_QualificationTypeId",
                table: "Activities",
                column: "QualificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_QualificationTypes_QualificationTypeId",
                table: "Activities",
                column: "QualificationTypeId",
                principalTable: "QualificationTypes",
                principalColumn: "QualificationTypeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_QualificationTypes_QualificationTypeId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "QualificationTypes");

            migrationBuilder.DropIndex(
                name: "IX_Activities_QualificationTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "QualificationTypeId",
                table: "Activities");
        }
    }
}
