using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBot.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numder",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sms",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numder",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sms",
                table: "Users");
        }
    }
}
