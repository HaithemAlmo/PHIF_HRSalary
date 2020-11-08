using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Holiday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExtraWorkFixed",
                table: "Salaries",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "HolidayId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayFrom = table.Column<short>(nullable: false),
                    DayTo = table.Column<short>(nullable: false),
                    MonthFrom = table.Column<short>(nullable: false),
                    MonthTo = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_HolidayId",
                table: "Activities",
                column: "HolidayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Holidays_HolidayId",
                table: "Activities",
                column: "HolidayId",
                principalTable: "Holidays",
                principalColumn: "HolidayId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Holidays_HolidayId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Activities_HolidayId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ExtraWorkFixed",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "HolidayId",
                table: "Activities");
        }
    }
}
