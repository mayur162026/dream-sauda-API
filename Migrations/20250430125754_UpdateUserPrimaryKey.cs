using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dreamsauda.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleEntries_Users_UserId",
                table: "BattleEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_UserId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WalletBalance",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "LoginUser");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LoginUser",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginUser",
                table: "LoginUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEntries_LoginUser_UserId",
                table: "BattleEntries",
                column: "UserId",
                principalTable: "LoginUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_LoginUser_UserId",
                table: "Teams",
                column: "UserId",
                principalTable: "LoginUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleEntries_LoginUser_UserId",
                table: "BattleEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_LoginUser_UserId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginUser",
                table: "LoginUser");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "LoginUser");

            migrationBuilder.RenameTable(
                name: "LoginUser",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "WalletBalance",
                table: "Users",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEntries_Users_UserId",
                table: "BattleEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_UserId",
                table: "Teams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
