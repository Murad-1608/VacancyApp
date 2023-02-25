using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Change1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "WorkExperience",
                table: "Jobs",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EducationId",
                table: "Jobs",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ExperienceId",
                table: "Jobs",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Education_EducationId",
                table: "Jobs",
                column: "EducationId",
                principalTable: "Education",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Experience_ExperienceId",
                table: "Jobs",
                column: "ExperienceId",
                principalTable: "Experience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Education_EducationId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Experience_ExperienceId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EducationId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ExperienceId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Jobs",
                newName: "WorkExperience");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
