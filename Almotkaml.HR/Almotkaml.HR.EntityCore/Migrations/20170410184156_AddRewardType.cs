using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddRewardType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RewardTypeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RewardTypes",
                columns: table => new
                {
                    RewardTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardTypes", x => x.RewardTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_RewardTypeId",
                table: "Activities",
                column: "RewardTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_RewardTypes_RewardTypeId",
                table: "Activities",
                column: "RewardTypeId",
                principalTable: "RewardTypes",
                principalColumn: "RewardTypeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_RewardTypes_RewardTypeId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "RewardTypes");

            migrationBuilder.DropIndex(
                name: "IX_Activities_RewardTypeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "RewardTypeId",
                table: "Activities");
        }
    }
}
