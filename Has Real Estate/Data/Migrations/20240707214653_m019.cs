using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Has_Real_Estate.Data.Migrations
{
    /// <inheritdoc />
    public partial class m019 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Estates",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_UserId",
                table: "Estates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Users_UserId",
                table: "Estates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Users_UserId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_UserId",
                table: "Estates");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Estates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
