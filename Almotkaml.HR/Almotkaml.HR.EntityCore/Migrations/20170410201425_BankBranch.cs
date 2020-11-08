using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class BankBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankBranchId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankBranches",
                columns: table => new
                {
                    BankBranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.BankBranchId);
                    table.ForeignKey(
                        name: "FK_BankBranches_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_BankBranchId",
                table: "Activities",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranches_BankId",
                table: "BankBranches",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_BankBranches_BankBranchId",
                table: "Activities",
                column: "BankBranchId",
                principalTable: "BankBranches",
                principalColumn: "BankBranchId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_BankBranches_BankBranchId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "BankBranches");

            migrationBuilder.DropIndex(
                name: "IX_Activities_BankBranchId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "BankBranchId",
                table: "Activities");
        }
    }
}
