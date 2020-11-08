using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingType",
                table: "Trainings");

            migrationBuilder.AddColumn<int>(
                name: "TrainingPlace",
                table: "Trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    CoursePlace = table.Column<int>(nullable: false),
                    FoundationName = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    TrainingType = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CityId",
                table: "Courses",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropColumn(
                name: "TrainingPlace",
                table: "Trainings");

            migrationBuilder.AddColumn<int>(
                name: "TrainingType",
                table: "Trainings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
