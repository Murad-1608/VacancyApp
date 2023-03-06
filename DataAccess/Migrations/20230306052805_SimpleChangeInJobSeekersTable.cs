using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SimpleChangeInJobSeekersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "JobSeekers",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "About",
                table: "JobSeekers",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "JobSeekers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "JobSeekers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "JobSeekers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "JobSeekers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "JobSeekers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "JobSeekers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_CategoryId",
                table: "JobSeekers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_CityId",
                table: "JobSeekers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_Categories_CategoryId",
                table: "JobSeekers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_Cities_CityId",
                table: "JobSeekers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_Categories_CategoryId",
                table: "JobSeekers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_Cities_CityId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_CategoryId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_CityId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "JobSeekers");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "JobSeekers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "JobSeekers",
                newName: "About");
        }
    }
}
