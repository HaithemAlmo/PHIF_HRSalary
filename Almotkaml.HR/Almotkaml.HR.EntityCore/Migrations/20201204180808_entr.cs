using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class entr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntrantsAndReviewerss",
                columns: table => new
                {
                    EntrantsAndReviewersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeeNumber = table.Column<int>(nullable: false),
                    EntrantsAndReviewersType = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    NationalNumber = table.Column<string>(maxLength: 128, nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrantsAndReviewerss", x => x.EntrantsAndReviewersId);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalAffairsDepartment",
                columns: table => new
                {
                    TechnicalAffairsDepartmentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccommodationReviewBayan = table.Column<bool>(nullable: false),
                    AccommodationReviewCount = table.Column<int>(nullable: false),
                    AccommodationReviewDemand = table.Column<bool>(nullable: false),
                    ClincReviewBayan = table.Column<bool>(nullable: false),
                    ClincReviewCount = table.Column<int>(nullable: false),
                    ClincReviewDemand = table.Column<bool>(nullable: false),
                    CorrectCount = table.Column<int>(nullable: false),
                    DataEntryBayan = table.Column<bool>(nullable: false),
                    DataEntryCount = table.Column<int>(nullable: false),
                    DataEntryDemand = table.Column<bool>(nullable: false),
                    EntrantsAndReviewersId = table.Column<int>(nullable: false),
                    FirstReviewBayan = table.Column<bool>(nullable: false),
                    FirstReviewCount = table.Column<int>(nullable: false),
                    FirstReviewDemand = table.Column<bool>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    IsNotCorrect = table.Column<bool>(nullable: false),
                    MonthWork = table.Column<int>(nullable: false),
                    YearWork = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalAffairsDepartment", x => x.TechnicalAffairsDepartmentId);
                    table.ForeignKey(
                        name: "FK_TechnicalAffairsDepartment_EntrantsAndReviewerss_EntrantsAndReviewersId",
                        column: x => x.EntrantsAndReviewersId,
                        principalTable: "EntrantsAndReviewerss",
                        principalColumn: "EntrantsAndReviewersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalAffairsDepartment_EntrantsAndReviewersId",
                table: "TechnicalAffairsDepartment",
                column: "EntrantsAndReviewersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalAffairsDepartment");

            migrationBuilder.DropTable(
                name: "EntrantsAndReviewerss");
        }
    }
}
