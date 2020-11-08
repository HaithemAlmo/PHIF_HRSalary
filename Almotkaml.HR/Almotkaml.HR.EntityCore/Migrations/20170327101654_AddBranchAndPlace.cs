using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddBranchAndPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Places_Branchs_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branchs",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_BranchId",
                table: "Activities",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PlaceId",
                table: "Activities",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_BranchId",
                table: "Places",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Branchs_BranchId",
                table: "Activities",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Places_PlaceId",
                table: "Activities",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Branchs_BranchId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Places_PlaceId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Branchs");

            migrationBuilder.DropIndex(
                name: "IX_Activities_BranchId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_PlaceId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Activities");
        }
    }
}
