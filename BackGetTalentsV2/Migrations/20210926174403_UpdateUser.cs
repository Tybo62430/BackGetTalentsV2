using Microsoft.EntityFrameworkCore.Migrations;

namespace BackGetTalentsV2.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "user");

            migrationBuilder.DropColumn(
                name: "presentation",
                table: "user");

            migrationBuilder.DropColumn(
                name: "role",
                table: "user");

            migrationBuilder.DropColumn(
                name: "status",
                table: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "phone",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "presentation",
                table: "user",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "user",
                type: "enum('ADMIN','USER')",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "user",
                type: "enum('AVAILABLE','UNAVAILABLE','BANNED','DEACTIVATED')",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
