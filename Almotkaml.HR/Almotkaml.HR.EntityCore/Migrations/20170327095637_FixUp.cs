using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.HR.EntityCore.Migrations
{
    public partial class FixUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Activities_ActivityId",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserGroups",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "_CreatedBy",
                table: "UserGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateCreated",
                table: "UserGroups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateModified",
                table: "UserGroups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "_ModifiedBy",
                table: "UserGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Users",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "_CreatedBy",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateModified",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "_ModifiedBy",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_CreatedBy",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateCreated",
                table: "Notifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateModified",
                table: "Notifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "_ModifiedBy",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Activities",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "_CreatedBy",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateCreated",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DateModified",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "_ModifiedBy",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "UserGroupId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Activities_ActivityId",
                table: "Notifications",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Activities_ActivityId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "_DateCreated",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "_DateModified",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "_ModifiedBy",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "_DateCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "_DateModified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "_ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_DateCreated",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_DateModified",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_ModifiedBy",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "_CreatedBy",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "_DateCreated",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "_DateModified",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "_ModifiedBy",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserGroups",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_UserGroups_UserGroupId",
                table: "Activities",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "UserGroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Activities_ActivityId",
                table: "Notifications",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
