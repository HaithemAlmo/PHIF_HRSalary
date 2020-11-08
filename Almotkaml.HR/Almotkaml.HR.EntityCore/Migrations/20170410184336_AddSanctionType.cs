using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddSanctionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SanctionTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SanctionTypes",
                columns: table => new
                {
                    SanctionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanctionTypes", x => x.SanctionTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SanctionTypeId",
                table: "Activities",
                column: "SanctionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SanctionTypes_SanctionTypeId",
                table: "Activities",
                column: "SanctionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "SanctionTypeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SanctionTypes_SanctionTypeId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "SanctionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SanctionTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SanctionTypeId",
                table: "Activities");
        }
    }
}
