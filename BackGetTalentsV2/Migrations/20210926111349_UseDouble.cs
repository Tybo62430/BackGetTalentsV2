using Microsoft.EntityFrameworkCore.Migrations;

namespace BackGetTalentsV2.Migrations
{
    public partial class UseDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "lng",
                table: "address",
                type: "double",
                precision: 10,
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "float",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "lat",
                table: "address",
                type: "double",
                precision: 10,
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "float",
                oldPrecision: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "lng",
                table: "address",
                type: "float",
                precision: 10,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<float>(
                name: "lat",
                table: "address",
                type: "float",
                precision: 10,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 10);
        }
    }
}
