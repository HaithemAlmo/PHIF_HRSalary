using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Premium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PremiumId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Premiums",
                columns: table => new
                {
                    PremiumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsSubject = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premiums", x => x.PremiumId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PremiumId",
                table: "Activities",
                column: "PremiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Premiums_PremiumId",
                table: "Activities",
                column: "PremiumId",
                principalTable: "Premiums",
                principalColumn: "PremiumId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryPremiums_Premiums_PremiumId",
                table: "SalaryPremiums",
                column: "PremiumId",
                principalTable: "Premiums",
                principalColumn: "PremiumId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Premiums_PremiumId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaryPremiums_Premiums_PremiumId",
                table: "SalaryPremiums");

            migrationBuilder.DropTable(
                name: "Premiums");

            migrationBuilder.DropIndex(
                name: "IX_Activities_PremiumId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "PremiumId",
                table: "Activities");
        }
    }
}
