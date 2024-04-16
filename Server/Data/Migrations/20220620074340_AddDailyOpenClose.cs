using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class AddDailyOpenClose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyOpenClose",
                columns: table => new
                {
                    Ticker = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    From = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Open = table.Column<double>(type: "float", nullable: false),
                    High = table.Column<double>(type: "float", nullable: false),
                    Low = table.Column<double>(type: "float", nullable: false),
                    Close = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<long>(type: "bigint", nullable: false),
                    AfterHours = table.Column<double>(type: "float", nullable: true),
                    PreMarket = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyOpenClose", x => new { x.Ticker, x.From });
                    table.ForeignKey(
                        name: "FK_DailyOpenClose_TickerResults_Ticker",
                        column: x => x.Ticker,
                        principalTable: "TickerResults",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyOpenClose");
        }
    }
}
