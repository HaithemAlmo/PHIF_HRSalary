using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class Transfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransferId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    TransferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    JobType = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.TransferId);
                    table.ForeignKey(
                        name: "FK_Transfers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TransferId",
                table: "Activities",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_EmployeeId",
                table: "Transfers",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Transfers_TransferId",
                table: "Activities",
                column: "TransferId",
                principalTable: "Transfers",
                principalColumn: "TransferId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Transfers_TransferId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TransferId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "Activities");
        }
    }
}
