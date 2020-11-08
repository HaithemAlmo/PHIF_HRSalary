using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddAdjectiveEmployeeAndType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdjectiveEmployeeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdjectiveEmployeeTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdjectiveEmployeeTypes",
                columns: table => new
                {
                    AdjectiveEmployeeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjectiveEmployeeTypes", x => x.AdjectiveEmployeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AdjectiveEmployees",
                columns: table => new
                {
                    AdjectiveEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdjectiveEmployeeTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjectiveEmployees", x => x.AdjectiveEmployeeId);
                    table.ForeignKey(
                        name: "FK_AdjectiveEmployees_AdjectiveEmployeeTypes_AdjectiveEmployeeTypeId",
                        column: x => x.AdjectiveEmployeeTypeId,
                        principalTable: "AdjectiveEmployeeTypes",
                        principalColumn: "AdjectiveEmployeeTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AdjectiveEmployeeId",
                table: "Activities",
                column: "AdjectiveEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AdjectiveEmployeeTypeId",
                table: "Activities",
                column: "AdjectiveEmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdjectiveEmployees_AdjectiveEmployeeTypeId",
                table: "AdjectiveEmployees",
                column: "AdjectiveEmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AdjectiveEmployees_AdjectiveEmployeeId",
                table: "Activities",
                column: "AdjectiveEmployeeId",
                principalTable: "AdjectiveEmployees",
                principalColumn: "AdjectiveEmployeeId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AdjectiveEmployeeTypes_AdjectiveEmployeeTypeId",
                table: "Activities",
                column: "AdjectiveEmployeeTypeId",
                principalTable: "AdjectiveEmployeeTypes",
                principalColumn: "AdjectiveEmployeeTypeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AdjectiveEmployees_AdjectiveEmployeeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AdjectiveEmployeeTypes_AdjectiveEmployeeTypeId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "AdjectiveEmployees");

            migrationBuilder.DropTable(
                name: "AdjectiveEmployeeTypes");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AdjectiveEmployeeId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AdjectiveEmployeeTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AdjectiveEmployeeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AdjectiveEmployeeTypeId",
                table: "Activities");
        }
    }
}
