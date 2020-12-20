using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApi.Migrations
{
    public partial class courseHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseHours",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseHours",
                table: "Applications");
        }
    }
}
