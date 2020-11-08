using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixUpDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Passports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Adjective",
                table: "JobInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CurrentClassification",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthStatus",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldJobNumber",
                table: "JobInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "Adjective",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "CurrentClassification",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "HealthStatus",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "OldJobNumber",
                table: "JobInfos");
        }
    }
}
