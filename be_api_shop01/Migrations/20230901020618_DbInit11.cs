using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_api_shop01.Migrations
{
    public partial class DbInit11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar",
                table: "user");

            migrationBuilder.DropColumn(
                name: "avatar",
                table: "customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "avatar",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "avatar",
                table: "customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
