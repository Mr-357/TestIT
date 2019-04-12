using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestIT.Data.Migrations
{
    public partial class Questions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Answer",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "x1",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "x2",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "y1",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "y2",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "Answer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "x1",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "x2",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "y1",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "y2",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "text",
                table: "Answer");
        }
    }
}
