using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class StoreStockChartData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockChartData",
                columns: table => new
                {
                    Ticker = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    Timespan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Multiplier = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Open = table.Column<double>(type: "float", nullable: false),
                    Low = table.Column<double>(type: "float", nullable: false),
                    Close = table.Column<double>(type: "float", nullable: false),
                    High = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(20,0)", precision: 20, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockChartData", x => new { x.Ticker, x.Timespan, x.Multiplier, x.Date });
                    table.ForeignKey(
                        name: "FK_StockChartData_TickerResults_Ticker",
                        column: x => x.Ticker,
                        principalTable: "TickerResults",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockChartData");
        }
    }
}
