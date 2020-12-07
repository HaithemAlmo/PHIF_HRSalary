using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class updateTechnical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccommodationReviewBayan",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "AccommodationReviewDemand",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "ClincReviewBayan",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "ClincReviewDemand",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "CorrectCount",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "DataEntryBayan",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "DataEntryDemand",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "FirstReviewBayan",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "FirstReviewDemand",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.RenameColumn(
                name: "IsNotCorrect",
                table: "TechnicalAffairsDepartment",
                newName: "IsPaid");

            migrationBuilder.AddColumn<decimal>(
                name: "AccommodationReviewBalance",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ClincReviewBalance",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DataEntryBalance",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FirstReviewBalance",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "TechnicalAffairsDepartment",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBalance",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccommodationReviewBalance",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "ClincReviewBalance",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "DataEntryBalance",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "FirstReviewBalance",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.DropColumn(
                name: "TotalBalance",
                table: "TechnicalAffairsDepartment");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "TechnicalAffairsDepartment",
                newName: "IsNotCorrect");

            migrationBuilder.AddColumn<bool>(
                name: "AccommodationReviewBayan",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AccommodationReviewDemand",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClincReviewBayan",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClincReviewDemand",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CorrectCount",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DataEntryBayan",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataEntryDemand",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FirstReviewBayan",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FirstReviewDemand",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "TechnicalAffairsDepartment",
                nullable: false,
                defaultValue: false);
        }
    }
}
