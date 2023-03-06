using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SimpleChangeInJobSeekersTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "JobSeekers",
                newName: "About");

            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "JobSeekers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_ExperienceId",
                table: "JobSeekers",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_Experiences_ExperienceId",
                table: "JobSeekers",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_Experiences_ExperienceId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_ExperienceId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "JobSeekers");

            migrationBuilder.RenameColumn(
                name: "About",
                table: "JobSeekers",
                newName: "Experience");
        }
    }
}
