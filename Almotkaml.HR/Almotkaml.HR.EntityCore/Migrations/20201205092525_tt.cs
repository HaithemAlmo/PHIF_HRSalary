using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalAffairsDepartment_EntrantsAndReviewerss_EntrantsAndReviewersId",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalAffairsDepartment_EntrantsAndReviewerss_EntrantsAndReviewersId",
                table: "TechnicalAffairsDepartment",
                column: "EntrantsAndReviewersId",
                principalTable: "EntrantsAndReviewerss",
                principalColumn: "EntrantsAndReviewersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalAffairsDepartment_EntrantsAndReviewerss_EntrantsAndReviewersId",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalAffairsDepartment_EntrantsAndReviewerss_EntrantsAndReviewersId",
                table: "TechnicalAffairsDepartment",
                column: "EntrantsAndReviewersId",
                principalTable: "EntrantsAndReviewerss",
                principalColumn: "EntrantsAndReviewersId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
