using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class addfoojobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SituionsNumber",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Situons",
                table: "JobInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SituionsNumber",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "Situons",
                table: "JobInfos");
        }
    }
}
