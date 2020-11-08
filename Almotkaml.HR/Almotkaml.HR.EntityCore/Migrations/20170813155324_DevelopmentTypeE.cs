using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class DevelopmentTypeE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DevelopmentTypeEId",
                table: "Activities",
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

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DevelopmentTypeEId",
                table: "Activities",
                column: "DevelopmentTypeEId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTypeEs_DevelopmentTypeDId",
                table: "DevelopmentTypeEs",
                column: "DevelopmentTypeDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DevelopmentTypeEs_DevelopmentTypeEId",
                table: "Activities",
                column: "DevelopmentTypeEId",
                principalTable: "DevelopmentTypeEs",
                principalColumn: "DevelopmentTypeEId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DevelopmentTypeEs_DevelopmentTypeEId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "DevelopmentTypeEs");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DevelopmentTypeEId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DevelopmentTypeEId",
                table: "Activities");
        }
    }
}
