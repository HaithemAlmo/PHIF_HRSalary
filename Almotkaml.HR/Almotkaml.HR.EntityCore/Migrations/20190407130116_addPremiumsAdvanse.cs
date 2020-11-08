using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class addPremiumsAdvanse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PremiumId",
                table: "AdvancePayments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AdvancePayments_PremiumId",
                table: "AdvancePayments",
                column: "PremiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvancePayments_Premiums_PremiumId",
                table: "AdvancePayments",
                column: "PremiumId",
                principalTable: "Premiums",
                principalColumn: "PremiumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvancePayments_Premiums_PremiumId",
                table: "AdvancePayments");

            migrationBuilder.DropIndex(
                name: "IX_AdvancePayments_PremiumId",
                table: "AdvancePayments");

            migrationBuilder.DropColumn(
                name: "PremiumId",
                table: "AdvancePayments");
        }
    }
}
