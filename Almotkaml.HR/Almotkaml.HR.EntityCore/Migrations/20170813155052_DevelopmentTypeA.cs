using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class DevelopmentTypeA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeAId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DevelopmentTypeAs",
                columns: table => new
                {
                    DevelopmentTypeAId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTypeAs", x => x.DevelopmentTypeAId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeAId",
                table: "Activities",
                column: "DevelopmentTypeAId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeAs_DevelopmentTypeAId",
                table: "Activities",
                column: "DevelopmentTypeAId",
                principalTable: "DevelopmentTypeAs",
                principalColumn: "DevelopmentTypeAId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeAs_DevelopmentTypeAId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "DevelopmentTypeAs");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeAId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeAId",
                table: "Activities");
        }
    }
}
