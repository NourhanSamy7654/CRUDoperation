using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Task5.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "coursesId",
                table: "Users",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Hour",
                table: "courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_coursesId",
                table: "Users",
                column: "coursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_courses_coursesId",
                table: "Users",
                column: "coursesId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_courses_coursesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_coursesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "coursesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "courses");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
