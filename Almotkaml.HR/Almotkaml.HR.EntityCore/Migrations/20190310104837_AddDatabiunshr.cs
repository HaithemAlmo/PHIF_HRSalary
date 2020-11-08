using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddDatabiunshr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bounshr",
                table: "JobInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBounshr",
                table: "JobInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bounshr",
                table: "JobInfos");

            migrationBuilder.DropColumn(
                name: "DateBounshr",
                table: "JobInfos");
        }
    }
}
