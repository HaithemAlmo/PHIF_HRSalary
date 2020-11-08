using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class DelegationModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DecisionDate",
                table: "Delegations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DelegationNumber",
                table: "Delegations",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QualificationTypeId",
                table: "Delegations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Delegations_QualificationTypeId",
                table: "Delegations",
                column: "QualificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Delegations_QualificationTypes_QualificationTypeId",
                table: "Delegations",
                column: "QualificationTypeId",
                principalTable: "QualificationTypes",
                principalColumn: "QualificationTypeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delegations_QualificationTypes_QualificationTypeId",
                table: "Delegations");

            migrationBuilder.DropIndex(
                name: "IX_Delegations_QualificationTypeId",
                table: "Delegations");

            migrationBuilder.DropColumn(
                name: "DecisionDate",
                table: "Delegations");

            migrationBuilder.DropColumn(
                name: "DelegationNumber",
                table: "Delegations");

            migrationBuilder.DropColumn(
                name: "QualificationTypeId",
                table: "Delegations");
        }
    }
}
