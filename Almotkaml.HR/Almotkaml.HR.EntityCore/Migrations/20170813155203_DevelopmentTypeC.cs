using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class DevelopmentTypeC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeCId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DevelopmentTypeCs",
                columns: table => new
                {
                    DevelopmentTypeCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DevelopmentTypeBId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTypeCs", x => x.DevelopmentTypeCId);
                    table.ForeignKey(
                        name: "FK_DevelopmentTypeCs_DevelopmentTypeBs_DevelopmentTypeBId",
                        column: x => x.DevelopmentTypeBId,
                        principalTable: "DevelopmentTypeBs",
                        principalColumn: "DevelopmentTypeBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeCId",
                table: "Activities",
                column: "DevelopmentTypeCId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTypeCs_DevelopmentTypeBId",
                table: "DevelopmentTypeCs",
                column: "DevelopmentTypeBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeCs_DevelopmentTypeCId",
                table: "Activities",
                column: "DevelopmentTypeCId",
                principalTable: "DevelopmentTypeCs",
                principalColumn: "DevelopmentTypeCId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeCs_DevelopmentTypeCId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "DevelopmentTypeCs");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeCId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeCId",
                table: "Activities");
        }
    }
}
