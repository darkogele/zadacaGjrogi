using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApi.Migrations
{
    public partial class dateToDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Dates",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
