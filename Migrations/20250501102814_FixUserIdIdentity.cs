using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dreamsauda.Migrations
{
    /// <inheritdoc />
    public partial class FixUserIdIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoginUser",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LoginUser",
                newName: "Id");
        }
    }
}
