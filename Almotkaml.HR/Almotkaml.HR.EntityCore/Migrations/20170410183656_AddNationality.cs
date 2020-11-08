using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class AddNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_NationalityId",
                table: "Activities",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Nationalities_NationalityId",
                table: "Activities",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Nationalities_NationalityId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_NationalityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Activities");
        }
    }
}
