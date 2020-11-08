using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddExtraWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExtraworkId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Extraworks",
                columns: table => new
                {
                    ExtraworkId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    DecisionNumber = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    TimeCount = table.Column<decimal>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extraworks", x => x.ExtraworkId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ExtraworkId",
                table: "Activities",
                column: "ExtraworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Extraworks_ExtraworkId",
                table: "Activities",
                column: "ExtraworkId",
                principalTable: "Extraworks",
                principalColumn: "ExtraworkId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Extraworks_ExtraworkId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Extraworks");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ExtraworkId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ExtraworkId",
                table: "Activities");
        }
    }
}
