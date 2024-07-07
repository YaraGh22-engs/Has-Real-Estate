using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Has_Real_Estate.Data.Migrations
{
    /// <inheritdoc />
    public partial class m013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedProperties_Estates_EstateId",
                table: "SavedProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedProperties_Users_AppUserId",
                table: "SavedProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedProperties",
                table: "SavedProperties");

            migrationBuilder.RenameTable(
                name: "SavedProperties",
                newName: "SavedProperty");

            migrationBuilder.RenameIndex(
                name: "IX_SavedProperties_EstateId",
                table: "SavedProperty",
                newName: "IX_SavedProperty_EstateId");

            migrationBuilder.RenameIndex(
                name: "IX_SavedProperties_AppUserId",
                table: "SavedProperty",
                newName: "IX_SavedProperty_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedProperty",
                table: "SavedProperty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedProperty_Estates_EstateId",
                table: "SavedProperty",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedProperty_Users_AppUserId",
                table: "SavedProperty",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedProperty_Estates_EstateId",
                table: "SavedProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedProperty_Users_AppUserId",
                table: "SavedProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedProperty",
                table: "SavedProperty");

            migrationBuilder.RenameTable(
                name: "SavedProperty",
                newName: "SavedProperties");

            migrationBuilder.RenameIndex(
                name: "IX_SavedProperty_EstateId",
                table: "SavedProperties",
                newName: "IX_SavedProperties_EstateId");

            migrationBuilder.RenameIndex(
                name: "IX_SavedProperty_AppUserId",
                table: "SavedProperties",
                newName: "IX_SavedProperties_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedProperties",
                table: "SavedProperties",
                column: "Id");

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
    }
}
