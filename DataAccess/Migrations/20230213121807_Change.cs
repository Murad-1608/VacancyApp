using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Josb_Categories_CategoryId",
                table: "Josb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Josb",
                table: "Josb");

            migrationBuilder.RenameTable(
                name: "Josb",
                newName: "Jobs");

            migrationBuilder.RenameIndex(
                name: "IX_Josb_CategoryId",
                table: "Jobs",
                newName: "IX_Jobs_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Josb");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CategoryId",
                table: "Josb",
                newName: "IX_Josb_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Josb",
                table: "Josb",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Josb_Categories_CategoryId",
                table: "Josb",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
