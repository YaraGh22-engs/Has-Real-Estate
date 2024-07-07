using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Has_Real_Estate.Data.Migrations
{
    /// <inheritdoc />
    public partial class m018 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Estates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_AppUserId",
                table: "Estates",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Users_AppUserId",
                table: "Estates",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Users_AppUserId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_AppUserId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Estates");
        }
    }
}
