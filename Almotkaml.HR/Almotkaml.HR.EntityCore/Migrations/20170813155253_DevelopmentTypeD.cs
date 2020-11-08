using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class DevelopmentTypeD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeDId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DevelopmentTypeDs",
                columns: table => new
                {
                    DevelopmentTypeDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DevelopmentTypeCId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTypeDs", x => x.DevelopmentTypeDId);
                    table.ForeignKey(
                        name: "FK_DevelopmentTypeDs_DevelopmentTypeCs_DevelopmentTypeCId",
                        column: x => x.DevelopmentTypeCId,
                        principalTable: "DevelopmentTypeCs",
                        principalColumn: "DevelopmentTypeCId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeDId",
                table: "Activities",
                column: "DevelopmentTypeDId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTypeDs_DevelopmentTypeCId",
                table: "DevelopmentTypeDs",
                column: "DevelopmentTypeCId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeDs_DevelopmentTypeDId",
                table: "Activities",
                column: "DevelopmentTypeDId",
                principalTable: "DevelopmentTypeDs",
                principalColumn: "DevelopmentTypeDId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeDs_DevelopmentTypeDId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "DevelopmentTypeDs");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeDId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeDId",
                table: "Activities");
        }
    }
}
