using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Delegation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DelegationId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Delegations",
                columns: table => new
                {
                    DelegationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    JobNumber = table.Column<string>(maxLength: 128, nullable: true),
                    JobTypeTransfer = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    SideName = table.Column<string>(maxLength: 1000, nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delegations", x => x.DelegationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DelegationId",
                table: "Activities",
                column: "DelegationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Delegations_DelegationId",
                table: "Activities",
                column: "DelegationId",
                principalTable: "Delegations",
                principalColumn: "DelegationId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Delegations_DelegationId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Delegations");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DelegationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DelegationId",
                table: "Activities");
        }
    }
}
