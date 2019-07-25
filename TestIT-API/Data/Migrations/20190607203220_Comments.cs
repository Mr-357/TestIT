using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34237f2a-3dbf-465a-be09-30ad287a600c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74578568-7c30-46f5-987d-b358fc94482c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91c08b3c-d2cc-4c20-9729-567122408b7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be984901-14e9-489a-af19-ef60d4ad8dd4");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Courses_ID",
                        column: x => x.ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4548fd25-8a19-4909-affc-c4a5dade7c96", "e4efb0fb-189b-4984-85f4-e7f8dd5050aa", "Admin", "ADMIN" },
                    { "46f2f4aa-dc70-41d0-952b-77ee05b5fd35", "6f598960-8e41-4708-9998-97e0c6a9a385", "Moderator", "MODERATOR" },
                    { "97cc6272-faf5-44b3-bf49-cae76f8cc295", "5e874a94-d62a-41c0-8927-886576be6196", "Student", "STUDENT" },
                    { "24afafec-d2af-451a-b244-7f4a2b1ac522", "b9d38235-7e0d-4b60-aa70-c1df9a621a8a", "Profesor", "PROFESOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CourseID",
                table: "Comment",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24afafec-d2af-451a-b244-7f4a2b1ac522");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4548fd25-8a19-4909-affc-c4a5dade7c96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46f2f4aa-dc70-41d0-952b-77ee05b5fd35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97cc6272-faf5-44b3-bf49-cae76f8cc295");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be984901-14e9-489a-af19-ef60d4ad8dd4", "784e8da0-d5a8-4c8a-946d-a423b8307803", "Admin", "ADMIN" },
                    { "74578568-7c30-46f5-987d-b358fc94482c", "3108592c-4620-40c5-b181-f5a5c7499ab8", "Moderator", "MODERATOR" },
                    { "91c08b3c-d2cc-4c20-9729-567122408b7a", "0c3494ed-4e18-4766-a8a7-5fbcb3f1253a", "Student", "STUDENT" },
                    { "34237f2a-3dbf-465a-be09-30ad287a600c", "6f7e3723-d0f9-4a0a-ad06-eacc223ec760", "Profesor", "PROFESOR" }
                });
        }
    }
}
