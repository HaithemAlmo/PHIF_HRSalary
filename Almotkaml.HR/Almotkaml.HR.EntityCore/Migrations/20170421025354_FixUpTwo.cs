using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixUpTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResolveResolutionDate",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "ResolveResolutionNumber",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "JobInfos");

            migrationBuilder.AlterColumn<int>(
                name: "Degree",
                table: "SituationResolveJobs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDegreeLast",
                table: "SituationResolveJobs",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Boun",
                table: "SituationResolveJobs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBounLast",
                table: "SituationResolveJobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBounLast",
                table: "SituationResolveJobs");

            migrationBuilder.AlterColumn<int>(
                name: "Degree",
                table: "SituationResolveJobs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDegreeLast",
                table: "SituationResolveJobs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Boun",
                table: "SituationResolveJobs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolveResolutionDate",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResolveResolutionNumber",
                table: "JobInfos",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "JobInfos",
                nullable: true);
        }
    }
}
