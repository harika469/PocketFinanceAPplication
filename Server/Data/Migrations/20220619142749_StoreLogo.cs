using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class StoreLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "TickerResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Logo",
                columns: table => new
                {
                    LogoUrl = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.LogoUrl);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TickerResults_Logo_LogoUrl",
                table: "TickerResults");

            migrationBuilder.DropTable(
                name: "Logo");

            migrationBuilder.DropIndex(
                name: "IX_TickerResults_LogoUrl",
                table: "TickerResults");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "TickerResults");
        }
    }
}
