using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceApp.Server.Data.Migrations
{
    public partial class StoreNewsResultImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "NewsResult");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "NewsResult",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "NewsResult");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "NewsResult",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
