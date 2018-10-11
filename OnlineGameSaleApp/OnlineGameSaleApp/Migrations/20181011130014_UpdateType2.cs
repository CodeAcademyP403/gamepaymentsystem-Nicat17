using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineGameSaleApp.Migrations
{
    public partial class UpdateType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_GameId",
                table: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GameId",
                table: "Payments",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_GameId",
                table: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GameId",
                table: "Payments",
                column: "GameId",
                unique: true);
        }
    }
}
