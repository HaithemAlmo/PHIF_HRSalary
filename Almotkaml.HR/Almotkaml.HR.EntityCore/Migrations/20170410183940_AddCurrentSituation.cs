using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddCurrentSituation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentSituationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrentSituations",
                columns: table => new
                {
                    CurrentSituationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentSituations", x => x.CurrentSituationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CurrentSituationId",
                table: "Activities",
                column: "CurrentSituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_CurrentSituations_CurrentSituationId",
                table: "Activities",
                column: "CurrentSituationId",
                principalTable: "CurrentSituations",
                principalColumn: "CurrentSituationId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_CurrentSituations_CurrentSituationId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "CurrentSituations");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CurrentSituationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CurrentSituationId",
                table: "Activities");
        }
    }
}
