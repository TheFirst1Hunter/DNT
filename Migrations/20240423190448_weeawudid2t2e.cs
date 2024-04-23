using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetTemplate.Migrations
{
    /// <inheritdoc />
    public partial class weeawudid2t2e : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntityType",
                table: "Auditions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "Auditions");
        }
    }
}
