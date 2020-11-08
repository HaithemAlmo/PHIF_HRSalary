using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class TrainingCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingCenterId",
                table: "Activities",
                nullable: true);

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
                name: "IX_Activities_TrainingCenterId",
                table: "Activities",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenters_CityId",
                table: "TrainingCenters",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_TrainingCenters_TrainingCenterId",
                table: "Activities",
                column: "TrainingCenterId",
                principalTable: "TrainingCenters",
                principalColumn: "TrainingCenterId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_TrainingCenters_TrainingCenterId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "TrainingCenters");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TrainingCenterId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TrainingCenterId",
                table: "Activities");
        }
    }
}
