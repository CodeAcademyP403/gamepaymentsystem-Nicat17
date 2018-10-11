using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGameSaleApp.Migrations
{
    public partial class UpdateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ip",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
