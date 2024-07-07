using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Has_Real_Estate.Data.Migrations
{
    /// <inheritdoc />
    public partial class m016 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SavedPropertyId",
                table: "Estates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SavedProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedProperties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estates_AppUserId",
                table: "Estates",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_SavedPropertyId",
                table: "Estates",
                column: "SavedPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_SavedProperties_SavedPropertyId",
                table: "Estates",
                column: "SavedPropertyId",
                principalTable: "SavedProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Estates_SavedProperties_SavedPropertyId",
                table: "Estates");

            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Users_AppUserId",
                table: "Estates");

            migrationBuilder.DropTable(
                name: "SavedProperties");

            migrationBuilder.DropIndex(
                name: "IX_Estates_AppUserId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_SavedPropertyId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "SavedPropertyId",
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
    }
}
