using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class EntrantsAndReviewers : Migration
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
                    Gender = table.Column<int>(nullable: false),
                    NationalNumber = table.Column<int>(maxLength: 128, nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntrantsAndReviewerss");
        }
    }
}
