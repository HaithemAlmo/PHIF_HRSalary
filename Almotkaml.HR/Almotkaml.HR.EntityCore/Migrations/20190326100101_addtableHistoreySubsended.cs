using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class addtableHistoreySubsended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubsendedSalary",
                table: "Salaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HistorySubsended",
                columns: table => new
                {
                    HistorySubsendedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateSubsended = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    HistorySubsendedNote = table.Column<string>(nullable: true),
                    ISSubsended = table.Column<bool>(nullable: false),
                    IsClose = table.Column<bool>(nullable: false),
                    JoubNumber = table.Column<string>(nullable: true),
                    NetSalray = table.Column<decimal>(nullable: false),
                    SalaryID = table.Column<string>(nullable: true),
                    iSCloseMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorySubsended", x => x.HistorySubsendedID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorySubsended");

            migrationBuilder.DropColumn(
                name: "IsSubsendedSalary",
                table: "Salaries");
        }
    }
}
