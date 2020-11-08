using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixUpThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Essential",
                table: "VacationTypes");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "Transfers");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Transfers",
                newName: "SideName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transfers",
                newName: "DateTo");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "EndServiceses",
                newName: "Cause");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "EndServiceses",
                newName: "DecisionDate");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                table: "VacationTypes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Days",
                table: "VacationTypes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VacationEssential",
                table: "VacationTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Transfers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JobTypeTransfer",
                table: "Transfers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobLastId",
                table: "SituationResolveJobs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobNowId",
                table: "SituationResolveJobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DecisionNumber",
                table: "EndServiceses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SituationResolveJobs_JobLastId",
                table: "SituationResolveJobs",
                column: "JobLastId");

            migrationBuilder.CreateIndex(
                name: "IX_SituationResolveJobs_JobNowId",
                table: "SituationResolveJobs",
                column: "JobNowId");

            migrationBuilder.AddForeignKey(
                name: "FK_SituationResolveJobs_Jobs_JobLastId",
                table: "SituationResolveJobs",
                column: "JobLastId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SituationResolveJobs_Jobs_JobNowId",
                table: "SituationResolveJobs",
                column: "JobNowId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SituationResolveJobs_Jobs_JobLastId",
                table: "SituationResolveJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SituationResolveJobs_Jobs_JobNowId",
                table: "SituationResolveJobs");

            migrationBuilder.DropIndex(
                name: "IX_SituationResolveJobs_JobLastId",
                table: "SituationResolveJobs");

            migrationBuilder.DropIndex(
                name: "IX_SituationResolveJobs_JobNowId",
                table: "SituationResolveJobs");

            migrationBuilder.DropColumn(
                name: "VacationEssential",
                table: "VacationTypes");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "JobTypeTransfer",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "JobLastId",
                table: "SituationResolveJobs");

            migrationBuilder.DropColumn(
                name: "JobNowId",
                table: "SituationResolveJobs");

            migrationBuilder.DropColumn(
                name: "DecisionNumber",
                table: "EndServiceses");

            migrationBuilder.RenameColumn(
                name: "SideName",
                table: "Transfers",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Transfers",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DecisionDate",
                table: "EndServiceses",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Cause",
                table: "EndServiceses",
                newName: "Note");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                table: "VacationTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Days",
                table: "VacationTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Essential",
                table: "VacationTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "JobType",
                table: "Transfers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
