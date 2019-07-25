using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class ImageChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Question",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<byte[]>(
                name: "Picture",
                table: "Question",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
        }
    }
}
