using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class AddQueryDateToChartDataKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StockChartData",
                table: "StockChartData");

            migrationBuilder.AddColumn<DateTime>(
                name: "QueryDate",
                table: "StockChartData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockChartData",
                table: "StockChartData",
                columns: new[] { "Ticker", "Timespan", "Multiplier", "QueryDate", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StockChartData",
                table: "StockChartData");

            migrationBuilder.DropColumn(
                name: "QueryDate",
                table: "StockChartData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockChartData",
                table: "StockChartData",
                columns: new[] { "Ticker", "Timespan", "Multiplier", "Date" });
        }
    }
}
