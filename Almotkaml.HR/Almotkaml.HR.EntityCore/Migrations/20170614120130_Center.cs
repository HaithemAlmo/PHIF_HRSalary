using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Center : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SubSpecialties_SubSpecialtyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_SubSpecialties_SubSpecialtyId",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_SubSpecialtyId",
                table: "Qualifications");

            migrationBuilder.RenameColumn(
                name: "SubSpecialtyId",
                table: "Qualifications",
                newName: "ExactSpecialtyId");

            migrationBuilder.RenameColumn(
                name: "SubSpecialtyId",
                table: "Employees",
                newName: "DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SubSpecialtyId",
                table: "Employees",
                newName: "IX_Employees_DivisionId");

            migrationBuilder.AlterColumn<string>(
                name: "JobNumber",
                table: "Salaries",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddColumn<bool>(
                name: "IsClose",
                table: "Salaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "MonthDate",
                table: "Salaries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AquiredSpecialty",
                table: "Qualifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LibyanOrForeigner",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    CenterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.CenterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CenterId",
                table: "Departments",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CenterId",
                table: "Activities",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Centers_CenterId",
                table: "Activities",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Centers_CenterId",
                table: "Departments",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Divisions_DivisionId",
                table: "Employees",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Centers_CenterId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Centers_CenterId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Divisions_DivisionId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CenterId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CenterId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "IsClose",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "MonthDate",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "AquiredSpecialty",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "LibyanOrForeigner",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "ExactSpecialtyId",
                table: "Qualifications",
                newName: "SubSpecialtyId");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Employees",
                newName: "SubSpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DivisionId",
                table: "Employees",
                newName: "IX_Employees_SubSpecialtyId");

            migrationBuilder.AlterColumn<string>(
                name: "JobNumber",
                table: "Salaries",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_SubSpecialtyId",
                table: "Qualifications",
                column: "SubSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SubSpecialties_SubSpecialtyId",
                table: "Employees",
                column: "SubSpecialtyId",
                principalTable: "SubSpecialties",
                principalColumn: "SubSpecialtyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_SubSpecialties_SubSpecialtyId",
                table: "Qualifications",
                column: "SubSpecialtyId",
                principalTable: "SubSpecialties",
                principalColumn: "SubSpecialtyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
