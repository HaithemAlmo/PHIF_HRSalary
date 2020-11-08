using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Training : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    DecisionNumber = table.Column<string>(maxLength: 128, nullable: true),
                    DeducationType = table.Column<int>(nullable: false),
                    DevelopmentStateId = table.Column<int>(nullable: false),
                    DevelopmentTypeEId = table.Column<int>(nullable: false),
                    DonorFoundationType = table.Column<int>(nullable: false),
                    ExecutingAgency = table.Column<string>(maxLength: 128, nullable: true),
                    NameDonorFoundation = table.Column<string>(maxLength: 128, nullable: true),
                    RequestedQualificationId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(maxLength: 128, nullable: true),
                    TrainingCenterId = table.Column<int>(nullable: false),
                    TrainingType = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_Trainings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_DevelopmentStates_DevelopmentStateId",
                        column: x => x.DevelopmentStateId,
                        principalTable: "DevelopmentStates",
                        principalColumn: "DevelopmentStateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_DevelopmentTypeEs_DevelopmentTypeEId",
                        column: x => x.DevelopmentTypeEId,
                        principalTable: "DevelopmentTypeEs",
                        principalColumn: "DevelopmentTypeEId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_RequestedQualifications_RequestedQualificationId",
                        column: x => x.RequestedQualificationId,
                        principalTable: "RequestedQualifications",
                        principalColumn: "RequestedQualificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingCenters_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "TrainingCenters",
                        principalColumn: "TrainingCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TrainingId",
                table: "Activities",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CityId",
                table: "Trainings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_DevelopmentStateId",
                table: "Trainings",
                column: "DevelopmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_DevelopmentTypeEId",
                table: "Trainings",
                column: "DevelopmentTypeEId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_RequestedQualificationId",
                table: "Trainings",
                column: "RequestedQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingCenterId",
                table: "Trainings",
                column: "TrainingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Trainings_TrainingId",
                table: "Activities",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "TrainingId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Trainings_TrainingId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TrainingId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Activities");
        }
    }
}
