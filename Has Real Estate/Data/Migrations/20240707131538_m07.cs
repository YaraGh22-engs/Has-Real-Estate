using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Has_Real_Estate.Data.Migrations
{
    /// <inheritdoc />
    public partial class m07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSaved",
                table: "Estates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSaved",
                table: "Estates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
