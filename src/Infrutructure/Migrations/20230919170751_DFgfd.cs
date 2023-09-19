using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.infrutructure.Migrations
{
    /// <inheritdoc />
    public partial class DFgfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products_Tags",
                table: "Products_Tags");

            migrationBuilder.DropIndex(
                name: "IX_Products_Tags_ProductId",
                table: "Products_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products_Images",
                table: "Products_Images");

            migrationBuilder.DropIndex(
                name: "IX_Products_Images_ProductId",
                table: "Products_Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories_Tags",
                table: "Categories_Tags");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Tags_CategoryId",
                table: "Categories_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories_Images",
                table: "Categories_Images");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Images_CategoryId",
                table: "Categories_Images");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products_Tags");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products_Tags");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Products_Tags");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Products_Tags");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Products_Tags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Products_Tags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products_Images");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products_Images");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Products_Images");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Products_Images");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Products_Images");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Products_Images");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories_Tags");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Categories_Tags");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Categories_Tags");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Categories_Tags");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Categories_Tags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories_Tags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories_Images");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Categories_Images");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Categories_Images");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Categories_Images");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Categories_Images");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories_Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Categories_Tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Categories_Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products_Tags",
                table: "Products_Tags",
                columns: new[] { "ProductId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products_Images",
                table: "Products_Images",
                columns: new[] { "ProductId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories_Tags",
                table: "Categories_Tags",
                columns: new[] { "CategoryId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories_Images",
                table: "Categories_Images",
                columns: new[] { "CategoryId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products_Tags",
                table: "Products_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products_Images",
                table: "Products_Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories_Tags",
                table: "Categories_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories_Images",
                table: "Categories_Images");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Products_Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Products_Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Products_Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Products_Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Products_Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Products_Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Products_Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Products_Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Products_Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Products_Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Products_Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Products_Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Categories_Tags",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Categories_Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Categories_Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Categories_Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Categories_Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Categories_Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Categories_Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Categories_Images",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Categories_Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Categories_Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Categories_Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Categories_Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Categories_Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Categories_Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products_Tags",
                table: "Products_Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products_Images",
                table: "Products_Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories_Tags",
                table: "Categories_Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories_Images",
                table: "Categories_Images",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Tags_ProductId",
                table: "Products_Tags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Images_ProductId",
                table: "Products_Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Tags_CategoryId",
                table: "Categories_Tags",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Images_CategoryId",
                table: "Categories_Images",
                column: "CategoryId");
        }
    }
}
