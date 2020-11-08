using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class UpdateSanction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeductionMonth",
                table: "Sanctions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeductionYear",
                table: "Sanctions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SanctionDay",
                table: "Sanctions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeductionMonth",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "DeductionYear",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "SanctionDay",
                table: "Sanctions");
        }
    }
}
