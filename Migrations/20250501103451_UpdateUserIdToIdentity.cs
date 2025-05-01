using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dreamsauda.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserIdToIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "LoginUser");
        }
    }
}
