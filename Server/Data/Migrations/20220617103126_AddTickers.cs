using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class AddTickers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Address1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Address1);
                });

            migrationBuilder.CreateTable(
                name: "Branding",
                columns: table => new
                {
                    LogoUrl = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branding", x => x.LogoUrl);
                });

            migrationBuilder.CreateTable(
                name: "TickerResults",
                columns: table => new
                {
                    Ticker = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Market = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryExchange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompositeFigi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShareClassFigi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketCap = table.Column<double>(type: "float", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SicCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SicDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TickerRoot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomepageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalEmployees = table.Column<int>(type: "int", nullable: true),
                    ListDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandingLogoUrl = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShareClassSharesOutstanding = table.Column<long>(type: "bigint", nullable: true),
                    WeightedSharesOutstanding = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TickerResults", x => x.Ticker);
                    table.ForeignKey(
                        name: "FK_TickerResults_Address_Address1",
                        column: x => x.Address1,
                        principalTable: "Address",
                        principalColumn: "Address1");
                    table.ForeignKey(
                        name: "FK_TickerResults_Branding_BrandingLogoUrl",
                        column: x => x.BrandingLogoUrl,
                        principalTable: "Branding",
                        principalColumn: "LogoUrl");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserTickerResults",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TickerWatchlistTicker = table.Column<string>(type: "nvarchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTickerResults", x => new { x.ApplicationUsersId, x.TickerWatchlistTicker });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTickerResults_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTickerResults_TickerResults_TickerWatchlistTicker",
                        column: x => x.TickerWatchlistTicker,
                        principalTable: "TickerResults",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTickerResults_TickerWatchlistTicker",
                table: "ApplicationUserTickerResults",
                column: "TickerWatchlistTicker");

            migrationBuilder.CreateIndex(
                name: "IX_TickerResults_Address1",
                table: "TickerResults",
                column: "Address1");

            migrationBuilder.CreateIndex(
                name: "IX_TickerResults_BrandingLogoUrl",
                table: "TickerResults",
                column: "BrandingLogoUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserTickerResults");

            migrationBuilder.DropTable(
                name: "TickerResults");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Branding");
        }
    }
}
