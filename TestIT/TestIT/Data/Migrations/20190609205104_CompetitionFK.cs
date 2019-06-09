using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class CompetitionFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Competitions",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03b691ae-773d-486c-b840-09e1bf0d7193", "28cbce25-fd03-4405-9265-d1454c8accab", "Admin", "ADMIN" },
                    { "6a4cd08e-3fd9-46b7-a639-c966a7c7cc7c", "e292a259-f251-490b-9a0d-5ad6a8bd2713", "Moderator", "MODERATOR" },
                    { "15aaa26a-0c2b-45a3-9aa4-3d6bab96fe21", "eb34a5cc-1a30-41e7-aa59-c52a191c7ff2", "Student", "STUDENT" },
                    { "9de2f03f-8f66-4181-9a0f-cca06b6314aa", "8b06d3fe-fb28-4ac8-a61e-a0742bd47c0e", "Profesor", "PROFESOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CourseID",
                table: "Competitions",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Courses_CourseID",
                table: "Competitions",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Courses_CourseID",
                table: "Competitions");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_CourseID",
                table: "Competitions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03b691ae-773d-486c-b840-09e1bf0d7193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15aaa26a-0c2b-45a3-9aa4-3d6bab96fe21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a4cd08e-3fd9-46b7-a639-c966a7c7cc7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9de2f03f-8f66-4181-9a0f-cca06b6314aa");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Competitions");

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
        }
    }
}
