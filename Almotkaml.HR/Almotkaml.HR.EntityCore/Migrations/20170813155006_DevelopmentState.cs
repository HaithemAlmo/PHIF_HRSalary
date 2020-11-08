using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class DevelopmentState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DevelopmentStateId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DevelopmentStates",
                columns: table => new
                {
                    DevelopmentStateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentStates", x => x.DevelopmentStateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentStateId",
                table: "Activities",
                column: "DevelopmentStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentStates_DevelopmentStateId",
                table: "Activities",
                column: "DevelopmentStateId",
                principalTable: "DevelopmentStates",
                principalColumn: "DevelopmentStateId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentStates_DevelopmentStateId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "DevelopmentStates");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentStateId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentStateId",
                table: "Activities");
        }
    }
}
