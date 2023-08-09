using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_api_shop01.Migrations
{
    public partial class DbInit03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "slider",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userAdded = table.Column<long>(type: "bigint", nullable: false),
                    userUpdated = table.Column<long>(type: "bigint", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slider", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "slider");
        }
    }
}
