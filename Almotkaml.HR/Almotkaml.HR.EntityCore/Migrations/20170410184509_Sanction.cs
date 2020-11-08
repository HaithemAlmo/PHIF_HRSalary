using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Sanction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SanctionId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sanctions",
                columns: table => new
                {
                    SanctionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cause = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    SanctionTypeId = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanctions", x => x.SanctionId);
                    table.ForeignKey(
                        name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                        column: x => x.SanctionTypeId,
                        principalTable: "SanctionTypes",
                        principalColumn: "SanctionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SanctionId",
                table: "Activities",
                column: "SanctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanctions_SanctionTypeId",
                table: "Sanctions",
                column: "SanctionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Sanctions_SanctionId",
                table: "Activities",
                column: "SanctionId",
                principalTable: "Sanctions",
                principalColumn: "SanctionId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Sanctions_SanctionId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Sanctions");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SanctionId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SanctionId",
                table: "Activities");
        }
    }
}
