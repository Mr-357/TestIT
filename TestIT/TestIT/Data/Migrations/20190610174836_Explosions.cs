using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class Explosions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_onCours_Courses_CourseID",
                table: "onCours");

            migrationBuilder.DropForeignKey(
                name: "FK_onCours_AspNetUsers_UserId",
                table: "onCours");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b672927-13cf-4b76-bc79-fac584c740e1", "c1ef25f1-90b4-47bd-9859-e7e0a99e8ae6", "Admin", "ADMIN" },
                    { "02109b9a-c66f-42e1-884c-88db02ba1886", "0a36aa82-64d9-4c01-abe1-1d75ff3f199f", "Moderator", "MODERATOR" },
                    { "c1891aec-87f2-459c-bac3-dd070d34bedb", "fc9c1d2a-2012-48bb-8488-adadc7959d2e", "Student", "STUDENT" },
                    { "9385de3a-88e5-435a-95b0-047339ea63a8", "8367620d-4283-4dfd-93b1-aa59e4833470", "Profesor", "PROFESOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_onCours_Courses_CourseID",
                table: "onCours",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_onCours_AspNetUsers_UserId",
                table: "onCours",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_onCours_Courses_CourseID",
                table: "onCours");

            migrationBuilder.DropForeignKey(
                name: "FK_onCours_AspNetUsers_UserId",
                table: "onCours");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02109b9a-c66f-42e1-884c-88db02ba1886");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b672927-13cf-4b76-bc79-fac584c740e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9385de3a-88e5-435a-95b0-047339ea63a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1891aec-87f2-459c-bac3-dd070d34bedb");

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

            migrationBuilder.AddForeignKey(
                name: "FK_onCours_Courses_CourseID",
                table: "onCours",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_onCours_AspNetUsers_UserId",
                table: "onCours",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
