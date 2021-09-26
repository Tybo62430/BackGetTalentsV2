using Microsoft.EntityFrameworkCore.Migrations;

namespace BackGetTalentsV2.Migrations
{
    public partial class DecimalToFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "lng",
                table: "address",
                type: "float",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "lat",
                table: "address",
                type: "float",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "lng",
                table: "address",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "lat",
                table: "address",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float",
                oldPrecision: 10,
                oldNullable: true);
        }
    }
}
