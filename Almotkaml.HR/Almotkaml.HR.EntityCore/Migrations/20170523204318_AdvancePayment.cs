using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AdvancePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvancePaymentId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdvancePayments",
                columns: table => new
                {
                    AdvancePaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeductionDate = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    InstallmentValue = table.Column<decimal>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvancePayments", x => x.AdvancePaymentId);
                    table.ForeignKey(
                        name: "FK_AdvancePayments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AdvancePaymentId",
                table: "Activities",
                column: "AdvancePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvancePayments_EmployeeId",
                table: "AdvancePayments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AdvancePayments_AdvancePaymentId",
                table: "Activities",
                column: "AdvancePaymentId",
                principalTable: "AdvancePayments",
                principalColumn: "AdvancePaymentId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AdvancePayments_AdvancePaymentId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "AdvancePayments");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AdvancePaymentId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AdvancePaymentId",
                table: "Activities");
        }
    }
}
