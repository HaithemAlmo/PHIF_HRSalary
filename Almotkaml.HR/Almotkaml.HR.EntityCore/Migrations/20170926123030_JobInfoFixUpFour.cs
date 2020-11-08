using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class JobInfoFixUpFour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JobNumber",
                table: "JobInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobNumber",
                table: "JobInfos",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
