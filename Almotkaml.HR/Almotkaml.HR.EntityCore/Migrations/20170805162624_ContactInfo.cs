using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class ContactInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WifeNationalityId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    ContactInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 128, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    NearKindr = table.Column<string>(maxLength: 128, nullable: true),
                    NearPoint = table.Column<string>(maxLength: 128, nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 128, nullable: true),
                    RelativeRelation = table.Column<string>(maxLength: 128, nullable: true),
                    WorkAddress = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.ContactInfoId);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WifeNationalityId",
                table: "Employees",
                column: "WifeNationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_EmployeeId",
                table: "ContactInfos",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Nationalities_WifeNationalityId",
                table: "Employees",
                column: "WifeNationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Nationalities_WifeNationalityId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WifeNationalityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WifeNationalityId",
                table: "Employees");
        }
    }
}
