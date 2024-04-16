using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class StoreNewsImagesInSeparateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "NewsResult");

            migrationBuilder.CreateTable(
                name: "NewsImage",
                columns: table => new
                {
                    IdNews = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsImage", x => x.IdNews);
                    table.ForeignKey(
                        name: "FK_NewsImage_NewsResult_IdNews",
                        column: x => x.IdNews,
                        principalTable: "NewsResult",
                        principalColumn: "IdNews",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsImage");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "NewsResult",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
