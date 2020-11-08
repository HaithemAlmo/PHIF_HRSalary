using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class TemporaryPremium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemporaryPremiumId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TemporaryPremiums",
                columns: table => new
                {
                    TemporaryPremiumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsSubject = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    SalaryId = table.Column<long>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporaryPremiums", x => x.TemporaryPremiumId);
                    table.ForeignKey(
                        name: "FK_TemporaryPremiums_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TemporaryPremiumId",
                table: "Activities",
                column: "TemporaryPremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryPremiums_SalaryId",
                table: "TemporaryPremiums",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_TemporaryPremiums_TemporaryPremiumId",
                table: "Activities",
                column: "TemporaryPremiumId",
                principalTable: "TemporaryPremiums",
                principalColumn: "TemporaryPremiumId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_TemporaryPremiums_TemporaryPremiumId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "TemporaryPremiums");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TemporaryPremiumId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TemporaryPremiumId",
                table: "Activities");
        }
    }
}
