using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetTemplate.Migrations
{
    /// <inheritdoc />
    public partial class _134222221 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Userss",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Userss");
        }
    }
}
