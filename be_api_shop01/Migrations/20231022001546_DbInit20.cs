using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_api_shop01.Migrations
{
    public partial class DbInit20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_product_category_product_parent_category_id",
                table: "category_product");

            migrationBuilder.DropIndex(
                name: "IX_category_product_parent_category_id",
                table: "category_product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_category_product_parent_category_id",
                table: "category_product",
                column: "parent_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_category_product_category_product_parent_category_id",
                table: "category_product",
                column: "parent_category_id",
                principalTable: "category_product",
                principalColumn: "id");
        }
    }
}
