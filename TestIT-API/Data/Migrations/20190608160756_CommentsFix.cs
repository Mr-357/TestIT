using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class CommentsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Courses_CourseID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Courses_ID",
                table: "Comment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05a754ea-151f-4f1f-b212-437b8099bd35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14c9f954-129d-489f-b2e6-9d38481e6c0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5f8ff1-b432-4fb6-a486-b2f92d02f171");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ef3a12e-fde2-457a-a61a-71431a416908");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Courses_CourseID",
                table: "Comment",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Courses_CourseID",
                table: "Comment");

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

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05a754ea-151f-4f1f-b212-437b8099bd35", "b298510e-e89a-4fa1-80e0-de8be49c2a22", "Admin", "ADMIN" },
                    { "3d5f8ff1-b432-4fb6-a486-b2f92d02f171", "0813c80b-8aac-45d4-9bc2-c4d58ef05bf3", "Moderator", "MODERATOR" },
                    { "14c9f954-129d-489f-b2e6-9d38481e6c0f", "9f1ff516-13da-4ab8-b738-bad05eb39dcd", "Student", "STUDENT" },
                    { "3ef3a12e-fde2-457a-a61a-71431a416908", "2ff5bf31-bde4-4cdf-bb14-46bcb4e76477", "Profesor", "PROFESOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Courses_CourseID",
                table: "Comment",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Courses_ID",
                table: "Comment",
                column: "ID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
