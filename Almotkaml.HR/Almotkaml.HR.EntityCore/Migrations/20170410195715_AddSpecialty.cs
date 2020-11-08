using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialtyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SpecialtyId",
                table: "Activities",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Specialties_SpecialtyId",
                table: "Activities",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Specialties_SpecialtyId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SpecialtyId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Activities");
        }
    }
}
