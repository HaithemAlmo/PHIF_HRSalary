using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class RequestedQualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestedQualificationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestedQualifications",
                columns: table => new
                {
                    RequestedQualificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedQualifications", x => x.RequestedQualificationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RequestedQualificationId",
                table: "Activities",
                column: "RequestedQualificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_RequestedQualifications_RequestedQualificationId",
                table: "Activities",
                column: "RequestedQualificationId",
                principalTable: "RequestedQualifications",
                principalColumn: "RequestedQualificationId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_RequestedQualifications_RequestedQualificationId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "RequestedQualifications");

            migrationBuilder.DropIndex(
                name: "IX_Activities_RequestedQualificationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "RequestedQualificationId",
                table: "Activities");
        }
    }
}
