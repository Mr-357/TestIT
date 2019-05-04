using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    numberOfQustionsPerTry = table.Column<int>(nullable: false),
                    time = table.Column<int>(nullable: false),
                    Visibility = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Quiz_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(nullable: true),
                    Points = table.Column<float>(nullable: false),
                    QuizID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Question_Quiz_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsCorrect = table.Column<bool>(nullable: false),
                    QuestionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionID",
                table: "Answer",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizID",
                table: "Question",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_ApplicationUserId",
                table: "Quiz",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
