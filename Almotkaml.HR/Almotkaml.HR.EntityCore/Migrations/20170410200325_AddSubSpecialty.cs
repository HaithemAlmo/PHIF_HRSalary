using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddSubSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubSpecialtyId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubSpecialties",
                columns: table => new
                {
                    SubSpecialtyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    SpecialtyId = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSpecialties", x => x.SubSpecialtyId);
                    table.ForeignKey(
                        name: "FK_SubSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SubSpecialtyId",
                table: "Activities",
                column: "SubSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSpecialties_SpecialtyId",
                table: "SubSpecialties",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SubSpecialties_SubSpecialtyId",
                table: "Activities",
                column: "SubSpecialtyId",
                principalTable: "SubSpecialties",
                principalColumn: "SubSpecialtyId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SubSpecialties_SubSpecialtyId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "SubSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SubSpecialtyId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SubSpecialtyId",
                table: "Activities");
        }
    }
}
