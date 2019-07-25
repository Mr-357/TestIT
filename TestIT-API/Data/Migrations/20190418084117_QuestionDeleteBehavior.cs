using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class QuestionDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizID",
                table: "Question");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizID",
                table: "Question",
                column: "QuizID",
                principalTable: "Quiz",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizID",
                table: "Question");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizID",
                table: "Question",
                column: "QuizID",
                principalTable: "Quiz",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
