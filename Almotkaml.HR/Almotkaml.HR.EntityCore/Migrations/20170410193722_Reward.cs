using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Reward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RewardId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    RewardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EfficiencyEstimate = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    RewardTypeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.RewardId);
                    table.ForeignKey(
                        name: "FK_Rewards_RewardTypes_RewardTypeId",
                        column: x => x.RewardTypeId,
                        principalTable: "RewardTypes",
                        principalColumn: "RewardTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RewardId",
                table: "Activities",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_RewardTypeId",
                table: "Rewards",
                column: "RewardTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Rewards_RewardId",
                table: "Activities",
                column: "RewardId",
                principalTable: "Rewards",
                principalColumn: "RewardId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Rewards_RewardId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Activities_RewardId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "RewardId",
                table: "Activities");
        }
    }
}
