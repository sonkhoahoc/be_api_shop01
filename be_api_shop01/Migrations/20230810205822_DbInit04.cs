using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_api_shop01.Migrations
{
    public partial class DbInit04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_is",
                table: "size",
                newName: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "size",
                newName: "product_is");
        }
    }
}
