using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneralAPI.Migrations
{
    /// <inheritdoc />
    public partial class UsersEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "Name");
        }
    }
}
