using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class RoleSeedDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "955601ae-b578-4638-9e15-a4652797713b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f0979c-c080-4010-923c-0d217820a4f2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5569518-fe56-4631-a66d-bd1b01b4ceda", "826cc343-fc58-4294-a378-43e14d0c5f98", "Admin", "ADMIN" },
                    { "9a9319eb-9060-4624-978f-9efedcf9dfb8", "83ed0043-e378-4d1b-9203-35feb584b46e", "Moderator", "MODERATOR" },
                    { "33218622-37d8-4f3e-8ac0-bd34b4acfa0f", "a44c8e9c-9d89-4fa9-bcf8-6308b8c4eaac", "Student", "STUDENT" },
                    { "8faf6aa6-8c29-460e-8882-37bfcc693147", "27569c96-afde-4663-9a5e-29fb829c5f4c", "Profesor", "PROFESOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33218622-37d8-4f3e-8ac0-bd34b4acfa0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8faf6aa6-8c29-460e-8882-37bfcc693147");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a9319eb-9060-4624-978f-9efedcf9dfb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5569518-fe56-4631-a66d-bd1b01b4ceda");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "955601ae-b578-4638-9e15-a4652797713b", "73da4e3e-bc04-4574-b96c-efb92c72ca3a", "Student", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5f0979c-c080-4010-923c-0d217820a4f2", "ca37b4a3-ced3-4939-8386-32dfdba0dbac", "Profesor", null });
        }
    }
}
