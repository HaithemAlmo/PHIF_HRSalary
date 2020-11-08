using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class NotesInJobInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "JobInfos");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "JobInfos",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "JobInfos");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "JobInfos",
                nullable: true);
        }
    }
}
