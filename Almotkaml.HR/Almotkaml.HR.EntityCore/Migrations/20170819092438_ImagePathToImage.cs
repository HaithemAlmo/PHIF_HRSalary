using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class ImagePathToImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Employees");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Employees",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Employees",
                nullable: true);
        }
    }
}
