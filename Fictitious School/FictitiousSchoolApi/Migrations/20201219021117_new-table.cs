using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApi.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ApplicationId",
                table: "Participants",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CompanyId",
                table: "Applications",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Applications_ApplicationId",
                table: "Participants",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Applications_ApplicationId",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ApplicationId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Participants");
        }
    }
}
