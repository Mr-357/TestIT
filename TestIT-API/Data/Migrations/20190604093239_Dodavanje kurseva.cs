using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class Dodavanjekurseva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Quiz",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SchoolYear = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_CourseID",
                table: "Quiz",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Courses_CourseID",
                table: "Quiz",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Courses_CourseID",
                table: "Quiz");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_CourseID",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Quiz");
        }
    }
}
