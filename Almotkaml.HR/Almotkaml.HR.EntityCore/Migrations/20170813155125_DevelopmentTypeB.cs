using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class DevelopmentTypeB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeBId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DevelopmentTypeBs",
                columns: table => new
                {
                    DevelopmentTypeBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DevelopmentTypeAId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTypeBs", x => x.DevelopmentTypeBId);
                    table.ForeignKey(
                        name: "FK_DevelopmentTypeBs_DevelopmentTypeAs_DevelopmentTypeAId",
                        column: x => x.DevelopmentTypeAId,
                        principalTable: "DevelopmentTypeAs",
                        principalColumn: "DevelopmentTypeAId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeBId",
                table: "Activities",
                column: "DevelopmentTypeBId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTypeBs_DevelopmentTypeAId",
                table: "DevelopmentTypeBs",
                column: "DevelopmentTypeAId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeBs_DevelopmentTypeBId",
                table: "Activities",
                column: "DevelopmentTypeBId",
                principalTable: "DevelopmentTypeBs",
                principalColumn: "DevelopmentTypeBId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeBs_DevelopmentTypeBId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "DevelopmentTypeBs");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeBId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeBId",
                table: "Activities");
        }
    }
}
