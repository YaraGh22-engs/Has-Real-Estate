using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Has_Real_Estate.Data.Migrations
{
    /// <inheritdoc />
    public partial class m017 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_SavedProperties_SavedPropertyId",
                table: "Estates");

            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Users_AppUserId",
                table: "Estates");

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

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "SavedProperties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstateId",
                table: "SavedProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SavedProperties_AppUserId",
                table: "SavedProperties",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedProperties_EstateId",
                table: "SavedProperties",
                column: "EstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedProperties_Estates_EstateId",
                table: "SavedProperties",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedProperties_Users_AppUserId",
                table: "SavedProperties",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedProperties_Estates_EstateId",
                table: "SavedProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedProperties_Users_AppUserId",
                table: "SavedProperties");

            migrationBuilder.DropIndex(
                name: "IX_SavedProperties_AppUserId",
                table: "SavedProperties");

            migrationBuilder.DropIndex(
                name: "IX_SavedProperties_EstateId",
                table: "SavedProperties");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "SavedProperties");

            migrationBuilder.DropColumn(
                name: "EstateId",
                table: "SavedProperties");

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
    }
}
