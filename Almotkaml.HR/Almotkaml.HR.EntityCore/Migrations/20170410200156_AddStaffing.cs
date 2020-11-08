using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddStaffing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffingId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Staffings",
                columns: table => new
                {
                    StaffingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    StaffingTypeId = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffings", x => x.StaffingId);
                    table.ForeignKey(
                        name: "FK_Staffings_StaffingTypes_StaffingTypeId",
                        column: x => x.StaffingTypeId,
                        principalTable: "StaffingTypes",
                        principalColumn: "StaffingTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StaffingId",
                table: "Activities",
                column: "StaffingId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_StaffingTypeId",
                table: "Staffings",
                column: "StaffingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Staffings_StaffingId",
                table: "Activities",
                column: "StaffingId",
                principalTable: "Staffings",
                principalColumn: "StaffingId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Staffings_StaffingId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Staffings");

            migrationBuilder.DropIndex(
                name: "IX_Activities_StaffingId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StaffingId",
                table: "Activities");
        }
    }
}
