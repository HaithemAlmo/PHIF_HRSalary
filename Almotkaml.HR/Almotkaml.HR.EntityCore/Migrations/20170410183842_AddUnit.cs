using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivisionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UnitId",
                table: "Activities",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_DivisionId",
                table: "Units",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Units_UnitId",
                table: "Activities",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Units_UnitId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UnitId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Activities");
        }
    }
}
