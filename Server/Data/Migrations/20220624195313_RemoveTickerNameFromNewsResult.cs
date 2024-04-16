using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class RemoveTickerNameFromNewsResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ticker",
                table: "NewsResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ticker",
                table: "NewsResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
