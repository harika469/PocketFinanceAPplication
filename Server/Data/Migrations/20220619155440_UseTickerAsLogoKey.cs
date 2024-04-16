using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class UseTickerAsLogoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TickerResults_Logo_LogoUrl",
                table: "TickerResults");

            migrationBuilder.DropIndex(
                name: "IX_TickerResults_LogoUrl",
                table: "TickerResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logo",
                table: "Logo");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "TickerResults");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Logo");

            migrationBuilder.AddColumn<string>(
                name: "Ticker",
                table: "Logo",
                type: "nvarchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logo",
                table: "Logo",
                column: "Ticker");

            migrationBuilder.AddForeignKey(
                name: "FK_Logo_TickerResults_Ticker",
                table: "Logo",
                column: "Ticker",
                principalTable: "TickerResults",
                principalColumn: "Ticker",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logo_TickerResults_Ticker",
                table: "Logo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logo",
                table: "Logo");

            migrationBuilder.DropColumn(
                name: "Ticker",
                table: "Logo");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "TickerResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Logo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logo",
                table: "Logo",
                column: "LogoUrl");

            migrationBuilder.CreateIndex(
                name: "IX_TickerResults_LogoUrl",
                table: "TickerResults",
                column: "LogoUrl");

            migrationBuilder.AddForeignKey(
                name: "FK_TickerResults_Logo_LogoUrl",
                table: "TickerResults",
                column: "LogoUrl",
                principalTable: "Logo",
                principalColumn: "LogoUrl");
        }
    }
}
