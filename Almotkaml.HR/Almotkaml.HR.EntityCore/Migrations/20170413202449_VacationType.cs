using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class VacationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SituationResolveJob",
                table: "JobInfos");

            migrationBuilder.AddColumn<int>(
                name: "VacationTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                columns: table => new
                {
                    VacationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Days = table.Column<int>(nullable: false),
                    DiscountPercentage = table.Column<int>(nullable: false),
                    Essential = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.VacationTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_VacationTypeId",
                table: "Activities",
                column: "VacationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_VacationTypes_VacationTypeId",
                table: "Activities",
                column: "VacationTypeId",
                principalTable: "VacationTypes",
                principalColumn: "VacationTypeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_VacationTypes_VacationTypeId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "VacationTypes");

            migrationBuilder.DropIndex(
                name: "IX_Activities_VacationTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "VacationTypeId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "SituationResolveJob",
                table: "JobInfos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
