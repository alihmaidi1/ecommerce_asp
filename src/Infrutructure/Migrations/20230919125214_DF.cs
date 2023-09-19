using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.infrutructure.Migrations
{
    /// <inheritdoc />
    public partial class DF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_Categories_CategoryId",
                table: "Categories_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Tags_Categories_CategoryId",
                table: "Categories_Tags");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Images_Categories_CategoryId",
                table: "Categories_Images",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Tags_Categories_CategoryId",
                table: "Categories_Tags",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_Categories_CategoryId",
                table: "Categories_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Tags_Categories_CategoryId",
                table: "Categories_Tags");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Images_Categories_CategoryId",
                table: "Categories_Images",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Tags_Categories_CategoryId",
                table: "Categories_Tags",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
