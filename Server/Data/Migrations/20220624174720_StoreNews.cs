using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class StoreNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HomepageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaviconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "NewsResult",
                columns: table => new
                {
                    IdNews = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsResult", x => x.IdNews);
                    table.ForeignKey(
                        name: "FK_NewsResult_Publisher_PublisherName",
                        column: x => x.PublisherName,
                        principalTable: "Publisher",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsResultTickerResults",
                columns: table => new
                {
                    NewsResultsIdNews = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TickerResultsTicker = table.Column<string>(type: "nvarchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsResultTickerResults", x => new { x.NewsResultsIdNews, x.TickerResultsTicker });
                    table.ForeignKey(
                        name: "FK_NewsResultTickerResults_NewsResult_NewsResultsIdNews",
                        column: x => x.NewsResultsIdNews,
                        principalTable: "NewsResult",
                        principalColumn: "IdNews",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsResultTickerResults_TickerResults_TickerResultsTicker",
                        column: x => x.TickerResultsTicker,
                        principalTable: "TickerResults",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsResult_PublisherName",
                table: "NewsResult",
                column: "PublisherName");

            migrationBuilder.CreateIndex(
                name: "IX_NewsResultTickerResults_TickerResultsTicker",
                table: "NewsResultTickerResults",
                column: "TickerResultsTicker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsResultTickerResults");

            migrationBuilder.DropTable(
                name: "NewsResult");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
