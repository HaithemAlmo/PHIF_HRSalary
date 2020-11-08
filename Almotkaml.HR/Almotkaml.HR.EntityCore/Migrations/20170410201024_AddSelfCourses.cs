using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddSelfCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelfCoursesId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SelfCourses",
                columns: table => new
                {
                    SelfCoursesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    Place = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    SubSpecialtyId = table.Column<int>(nullable: false),
                    TrainingCenter = table.Column<string>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfCourses", x => x.SelfCoursesId);
                    table.ForeignKey(
                        name: "FK_SelfCourses_SubSpecialties_SubSpecialtyId",
                        column: x => x.SubSpecialtyId,
                        principalTable: "SubSpecialties",
                        principalColumn: "SubSpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SelfCoursesId",
                table: "Activities",
                column: "SelfCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_SelfCourses_SubSpecialtyId",
                table: "SelfCourses",
                column: "SubSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_SelfCourses_SelfCoursesId",
                table: "Activities",
                column: "SelfCoursesId",
                principalTable: "SelfCourses",
                principalColumn: "SelfCoursesId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_SelfCourses_SelfCoursesId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "SelfCourses");

            migrationBuilder.DropIndex(
                name: "IX_Activities_SelfCoursesId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SelfCoursesId",
                table: "Activities");
        }
    }
}
