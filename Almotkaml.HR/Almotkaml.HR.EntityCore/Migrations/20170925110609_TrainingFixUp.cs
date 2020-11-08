using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class TrainingFixUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_DevelopmentTypeEs_DevelopmentTypeEId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingCenters_TrainingCenterId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "DevelopmentTypeEs");

            migrationBuilder.DropTable(
                name: "TrainingCenters");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_DevelopmentTypeEId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeEId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "DonorFoundationType",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "NameDonorFoundation",
                table: "Trainings");

            migrationBuilder.RenameColumn(
                name: "TrainingCenterId",
                table: "Trainings",
                newName: "DevelopmentTypeDId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainings_TrainingCenterId",
                table: "Trainings",
                newName: "IX_Trainings_DevelopmentTypeDId");

            migrationBuilder.AlterColumn<int>(
                name: "RequestedQualificationId",
                table: "Trainings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DevelopmentStateId",
                table: "Trainings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CorporationId",
                table: "Trainings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Trainings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DecisionDate",
                table: "Trainings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TrainingType",
                table: "Trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainingType",
                table: "DevelopmentTypeAs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Corporations",
                columns: table => new
                {
                    CorporationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    DonorFoundationType = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 1000, nullable: true),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 1000, nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporations", x => x.CorporationId);
                    table.ForeignKey(
                        name: "FK_Corporations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CorporationId",
                table: "Trainings",
                column: "CorporationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CourseId",
                table: "Trainings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Corporations_CityId",
                table: "Corporations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Corporations_CorporationId",
                table: "Trainings",
                column: "CorporationId",
                principalTable: "Corporations",
                principalColumn: "CorporationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Courses_CourseId",
                table: "Trainings",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_DevelopmentTypeDs_DevelopmentTypeDId",
                table: "Trainings",
                column: "DevelopmentTypeDId",
                principalTable: "DevelopmentTypeDs",
                principalColumn: "DevelopmentTypeDId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Corporations_CorporationId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Courses_CourseId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_DevelopmentTypeDs_DevelopmentTypeDId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "Corporations");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CorporationId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CourseId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CorporationId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "DecisionDate",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingType",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingType",
                table: "DevelopmentTypeAs");

            migrationBuilder.RenameColumn(
                name: "DevelopmentTypeDId",
                table: "Trainings",
                newName: "TrainingCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainings_DevelopmentTypeDId",
                table: "Trainings",
                newName: "IX_Trainings_TrainingCenterId");

            migrationBuilder.AlterColumn<int>(
                name: "RequestedQualificationId",
                table: "Trainings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DevelopmentStateId",
                table: "Trainings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeEId",
                table: "Trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonorFoundationType",
                table: "Trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameDonorFoundation",
                table: "Trainings",
                maxLength: 128,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DevelopmentTypeEs",
                columns: table => new
                {
                    DevelopmentTypeEId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DevelopmentTypeDId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTypeEs", x => x.DevelopmentTypeEId);
                    table.ForeignKey(
                        name: "FK_DevelopmentTypeEs_DevelopmentTypeDs_DevelopmentTypeDId",
                        column: x => x.DevelopmentTypeDId,
                        principalTable: "DevelopmentTypeDs",
                        principalColumn: "DevelopmentTypeDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCenters",
                columns: table => new
                {
                    TrainingCenterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 1000, nullable: true),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 1000, nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCenters", x => x.TrainingCenterId);
                    table.ForeignKey(
                        name: "FK_TrainingCenters_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_DevelopmentTypeEId",
                table: "Trainings",
                column: "DevelopmentTypeEId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTypeEs_DevelopmentTypeDId",
                table: "DevelopmentTypeEs",
                column: "DevelopmentTypeDId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenters_CityId",
                table: "TrainingCenters",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_DevelopmentTypeEs_DevelopmentTypeEId",
                table: "Trainings",
                column: "DevelopmentTypeEId",
                principalTable: "DevelopmentTypeEs",
                principalColumn: "DevelopmentTypeEId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingCenters_TrainingCenterId",
                table: "Trainings",
                column: "TrainingCenterId",
                principalTable: "TrainingCenters",
                principalColumn: "TrainingCenterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
