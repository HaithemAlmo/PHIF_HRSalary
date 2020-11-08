using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class EndServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndServicesId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EndServiceses",
                columns: table => new
                {
                    EndServicesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CauseOfEndService = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndServiceses", x => x.EndServicesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EndServicesId",
                table: "Activities",
                column: "EndServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_EndServiceses_EndServicesId",
                table: "Activities",
                column: "EndServicesId",
                principalTable: "EndServiceses",
                principalColumn: "EndServicesId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_EndServiceses_EndServicesId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "EndServiceses");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EndServicesId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EndServicesId",
                table: "Activities");
        }
    }
}
