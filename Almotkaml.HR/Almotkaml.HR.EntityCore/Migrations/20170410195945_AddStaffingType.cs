using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddStaffingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffingTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffingTypes",
                columns: table => new
                {
                    StaffingTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffingTypes", x => x.StaffingTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StaffingTypeId",
                table: "Activities",
                column: "StaffingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_StaffingTypes_StaffingTypeId",
                table: "Activities",
                column: "StaffingTypeId",
                principalTable: "StaffingTypes",
                principalColumn: "StaffingTypeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_StaffingTypes_StaffingTypeId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "StaffingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Activities_StaffingTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StaffingTypeId",
                table: "Activities");
        }
    }
}
