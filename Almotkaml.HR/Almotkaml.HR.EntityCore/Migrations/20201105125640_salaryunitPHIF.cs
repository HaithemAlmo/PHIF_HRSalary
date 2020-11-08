using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class salaryunitPHIF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeaderSalaryOfficeHeads_UpTo21",
                table: "SalaryUnits",
                newName: "HIF9");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryOfficeHeads_6To10",
                table: "SalaryUnits",
                newName: "HIF8");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryOfficeHeads_1To5",
                table: "SalaryUnits",
                newName: "HIF7");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryOfficeHeads_16To20",
                table: "SalaryUnits",
                newName: "HIF6");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryOfficeHeads_11To15",
                table: "SalaryUnits",
                newName: "HIF5");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryHeadDepartment_UpTo21",
                table: "SalaryUnits",
                newName: "HIF4");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryHeadDepartment_6To10",
                table: "SalaryUnits",
                newName: "HIF3");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryHeadDepartment_1To5",
                table: "SalaryUnits",
                newName: "HIF2");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryHeadDepartment_16To20",
                table: "SalaryUnits",
                newName: "HIF12");

            migrationBuilder.RenameColumn(
                name: "LeaderSalaryHeadDepartment_11To15",
                table: "SalaryUnits",
                newName: "HIF11");

            migrationBuilder.RenameColumn(
                name: "ExtraValue",
                table: "SalaryUnits",
                newName: "HIF10");

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue1",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue10",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue11",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue12",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue2",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue3",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue4",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue5",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue6",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue7",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue8",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraValue9",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HIF1",
                table: "SalaryUnits",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraValue1",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue10",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue11",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue12",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue2",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue3",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue4",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue5",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue6",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue7",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue8",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "ExtraValue9",
                table: "SalaryUnits");

            migrationBuilder.DropColumn(
                name: "HIF1",
                table: "SalaryUnits");

            migrationBuilder.RenameColumn(
                name: "HIF9",
                table: "SalaryUnits",
                newName: "LeaderSalaryOfficeHeads_UpTo21");

            migrationBuilder.RenameColumn(
                name: "HIF8",
                table: "SalaryUnits",
                newName: "LeaderSalaryOfficeHeads_6To10");

            migrationBuilder.RenameColumn(
                name: "HIF7",
                table: "SalaryUnits",
                newName: "LeaderSalaryOfficeHeads_1To5");

            migrationBuilder.RenameColumn(
                name: "HIF6",
                table: "SalaryUnits",
                newName: "LeaderSalaryOfficeHeads_16To20");

            migrationBuilder.RenameColumn(
                name: "HIF5",
                table: "SalaryUnits",
                newName: "LeaderSalaryOfficeHeads_11To15");

            migrationBuilder.RenameColumn(
                name: "HIF4",
                table: "SalaryUnits",
                newName: "LeaderSalaryHeadDepartment_UpTo21");

            migrationBuilder.RenameColumn(
                name: "HIF3",
                table: "SalaryUnits",
                newName: "LeaderSalaryHeadDepartment_6To10");

            migrationBuilder.RenameColumn(
                name: "HIF2",
                table: "SalaryUnits",
                newName: "LeaderSalaryHeadDepartment_1To5");

            migrationBuilder.RenameColumn(
                name: "HIF12",
                table: "SalaryUnits",
                newName: "LeaderSalaryHeadDepartment_16To20");

            migrationBuilder.RenameColumn(
                name: "HIF11",
                table: "SalaryUnits",
                newName: "LeaderSalaryHeadDepartment_11To15");

            migrationBuilder.RenameColumn(
                name: "HIF10",
                table: "SalaryUnits",
                newName: "ExtraValue");
        }
    }
}
