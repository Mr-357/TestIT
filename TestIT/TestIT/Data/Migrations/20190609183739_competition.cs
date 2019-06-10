using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class competition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0738c1a1-7480-41f9-8abb-aef445a7b9da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15159fa3-0b22-4f37-92a3-0439f87602c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "338ba17a-9836-4dd5-b235-d7e461625087");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6bcea6b-1760-4c4b-a49e-a02293464b53");

            migrationBuilder.AlterColumn<double>(
                name: "y2",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "y1",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "x2",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "x1",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuizID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competitions_Quiz_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    CompetitionID = table.Column<int>(nullable: true),
                    Score = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Participation_Competitions_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Participation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cbea2dc5-e79b-4c8e-bd78-05830e91a16d", "479d6748-975e-4b14-843a-6a93e10dd854", "Admin", "ADMIN" },
                    { "3e816274-90c5-4c59-897c-e66eb0974f3a", "5c076711-dfa4-4d97-9846-753623404f3d", "Moderator", "MODERATOR" },
                    { "4e4e01ae-ff86-485a-a67b-94bb7e3e2169", "cd5b3d61-3a4d-4a75-898e-77162c5ab809", "Student", "STUDENT" },
                    { "f949e171-c0f5-420d-bd7d-1e40bc5c720a", "084c866e-023c-430c-ae1a-47f81889f727", "Profesor", "PROFESOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_QuizID",
                table: "Competitions",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_CompetitionID",
                table: "Participation",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_UserId",
                table: "Participation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e816274-90c5-4c59-897c-e66eb0974f3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e4e01ae-ff86-485a-a67b-94bb7e3e2169");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbea2dc5-e79b-4c8e-bd78-05830e91a16d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f949e171-c0f5-420d-bd7d-1e40bc5c720a");

            migrationBuilder.AlterColumn<float>(
                name: "y2",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "y1",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "x2",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "x1",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "338ba17a-9836-4dd5-b235-d7e461625087", "dc0ad634-2aa2-474a-adb0-b92ffc7caffc", "Admin", "ADMIN" },
                    { "f6bcea6b-1760-4c4b-a49e-a02293464b53", "9976a0b7-d792-4461-9edf-85c27a4e40e1", "Moderator", "MODERATOR" },
                    { "0738c1a1-7480-41f9-8abb-aef445a7b9da", "c2e9a6a6-e125-41e7-9e8f-938fe3a9ff11", "Student", "STUDENT" },
                    { "15159fa3-0b22-4f37-92a3-0439f87602c9", "4f5757fc-9adc-4dcc-ab77-82bc83d7a601", "Profesor", "PROFESOR" }
                });
        }
    }
}
