using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class JobTableSubCategoryAndCategoryChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Jobs",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                newName: "IX_Jobs_SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_SubCategories_SubCategoryId",
                table: "Jobs",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_SubCategories_SubCategoryId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "Jobs",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_SubCategoryId",
                table: "Jobs",
                newName: "IX_Jobs_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
