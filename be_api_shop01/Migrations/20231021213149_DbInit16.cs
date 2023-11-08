using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_api_shop01.Migrations
{
    public partial class DbInit16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Category_Productid",
                table: "category_product",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_category_product_Category_Productid",
                table: "category_product",
                column: "Category_Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_category_product_category_product_Category_Productid",
                table: "category_product",
                column: "Category_Productid",
                principalTable: "category_product",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_product_category_product_Category_Productid",
                table: "category_product");

            migrationBuilder.DropIndex(
                name: "IX_category_product_Category_Productid",
                table: "category_product");

            migrationBuilder.DropColumn(
                name: "Category_Productid",
                table: "category_product");
        }
    }
}
