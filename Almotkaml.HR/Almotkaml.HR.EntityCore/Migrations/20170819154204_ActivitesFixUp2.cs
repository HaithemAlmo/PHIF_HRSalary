using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class ActivitesFixUp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_DateCreated",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_DateModified",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_ModifiedBy",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "_DateCreated",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "_DateModified",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "_ModifiedBy",
                table: "Activities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_CreatedBy",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateCreated",
                table: "Notifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateModified",
                table: "Notifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "_ModifiedBy",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_CreatedBy",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateCreated",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateModified",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "_ModifiedBy",
                table: "Activities",
                nullable: false,
                defaultValue: 0);
        }
    }
}
