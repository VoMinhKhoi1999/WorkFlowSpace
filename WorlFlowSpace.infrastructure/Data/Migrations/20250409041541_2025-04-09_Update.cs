using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlowSpace.infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20250409_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Tasks",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Tasks",
                type: "int",
                maxLength: 200,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiDate",
                table: "Tasks",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiDate",
                table: "Tabs",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiDate",
                table: "Groups",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ModifiDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ModifiDate",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "ModifiDate",
                table: "Groups");
        }
    }
}
