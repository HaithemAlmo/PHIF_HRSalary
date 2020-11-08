using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddSpecialitiesToQualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Qualifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSpecialtyId",
                table: "Qualifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_SpecialtyId",
                table: "Qualifications",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_SubSpecialtyId",
                table: "Qualifications",
                column: "SubSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Specialties_SpecialtyId",
                table: "Qualifications",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_SubSpecialties_SubSpecialtyId",
                table: "Qualifications",
                column: "SubSpecialtyId",
                principalTable: "SubSpecialties",
                principalColumn: "SubSpecialtyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Specialties_SpecialtyId",
                table: "Qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_SubSpecialties_SubSpecialtyId",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_SpecialtyId",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_SubSpecialtyId",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "SubSpecialtyId",
                table: "Qualifications");
        }
    }
}
