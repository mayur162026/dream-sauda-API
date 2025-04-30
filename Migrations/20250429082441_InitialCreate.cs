using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dreamsauda.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletBalance = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    EntryFee = table.Column<decimal>(nullable: false),
                    Points = table.Column<decimal>(nullable: false),
                    IsWinner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {           
                    table.PrimaryKey("PK_BattleEntries", x => x.Id);
                    table.ForeignKey(
                    name: "FK_BattleEntries_Matches_MatchId",
                    column: x => x.MatchId,
                    principalTable: "Matches",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);  // This is fine, because it's a single path.
                    table.ForeignKey(
                    name: "FK_BattleEntries_Teams_TeamId",
                    column: x => x.TeamId,
                    principalTable: "Teams",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);  // This is fine as well.
                    table.ForeignKey(
                    name: "FK_BattleEntries_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);  // Change from Cascade to Restrict to avoid cycles.
                });

            migrationBuilder.CreateTable(
                name: "TeamStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamStocks_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamStocks_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleEntries_MatchId",
                table: "BattleEntries",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEntries_TeamId",
                table: "BattleEntries",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEntries_UserId",
                table: "BattleEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStocks_StockId",
                table: "TeamStocks",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStocks_TeamId_StockId",
                table: "TeamStocks",
                columns: new[] { "TeamId", "StockId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleEntries");

            migrationBuilder.DropTable(
                name: "TeamStocks");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
