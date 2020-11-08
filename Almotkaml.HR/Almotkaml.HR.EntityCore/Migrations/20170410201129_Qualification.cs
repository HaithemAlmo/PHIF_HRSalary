using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Qualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    QualificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    GraduationCountry = table.Column<string>(nullable: true),
                    NameDonorFoundation = table.Column<string>(nullable: true),
                    QualificationTypeId = table.Column<int>(nullable: false),
                    SubSpecialtyId = table.Column<int>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_Qualifications_QualificationTypes_QualificationTypeId",
                        column: x => x.QualificationTypeId,
                        principalTable: "QualificationTypes",
                        principalColumn: "QualificationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Qualifications_SubSpecialties_SubSpecialtyId",
                        column: x => x.SubSpecialtyId,
                        principalTable: "SubSpecialties",
                        principalColumn: "SubSpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_QualificationId",
                table: "Activities",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_QualificationTypeId",
                table: "Qualifications",
                column: "QualificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_SubSpecialtyId",
                table: "Qualifications",
                column: "SubSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Qualifications_QualificationId",
                table: "Activities",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Qualifications_QualificationId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Activities_QualificationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Activities");
        }
    }
}
