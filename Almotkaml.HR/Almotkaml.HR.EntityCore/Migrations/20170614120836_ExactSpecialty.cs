using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class ExactSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExactSpecialtyId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CenterId",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExactSpecialtyId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExactSpecialties",
                columns: table => new
                {
                    ExactSpecialtyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    SubSpecialtyId = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExactSpecialties", x => x.ExactSpecialtyId);
                    table.ForeignKey(
                        name: "FK_ExactSpecialties_SubSpecialties_SubSpecialtyId",
                        column: x => x.SubSpecialtyId,
                        principalTable: "SubSpecialties",
                        principalColumn: "SubSpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_ExactSpecialtyId",
                table: "Qualifications",
                column: "ExactSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ExactSpecialtyId",
                table: "Employees",
                column: "ExactSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ExactSpecialtyId",
                table: "Activities",
                column: "ExactSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExactSpecialties_SubSpecialtyId",
                table: "ExactSpecialties",
                column: "SubSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ExactSpecialties_ExactSpecialtyId",
                table: "Activities",
                column: "ExactSpecialtyId",
                principalTable: "ExactSpecialties",
                principalColumn: "ExactSpecialtyId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ExactSpecialties_ExactSpecialtyId",
                table: "Employees",
                column: "ExactSpecialtyId",
                principalTable: "ExactSpecialties",
                principalColumn: "ExactSpecialtyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_ExactSpecialties_ExactSpecialtyId",
                table: "Qualifications",
                column: "ExactSpecialtyId",
                principalTable: "ExactSpecialties",
                principalColumn: "ExactSpecialtyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ExactSpecialties_ExactSpecialtyId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ExactSpecialties_ExactSpecialtyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_ExactSpecialties_ExactSpecialtyId",
                table: "Qualifications");

            migrationBuilder.DropTable(
                name: "ExactSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_ExactSpecialtyId",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ExactSpecialtyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ExactSpecialtyId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ExactSpecialtyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ExactSpecialtyId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "CenterId",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
