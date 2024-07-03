using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Has_Real_Estate.Data.Migrations
{
    /// <inheritdoc />
    public partial class model03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Estates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Estates");
        }
    }
}
