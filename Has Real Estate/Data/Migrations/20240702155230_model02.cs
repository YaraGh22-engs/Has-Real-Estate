using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Has_Real_Estate.Data.Migrations
{
    /// <inheritdoc />
    public partial class model02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeImages_Homes_HomeId",
                table: "HomeImages");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.RenameColumn(
                name: "HomeId",
                table: "HomeImages",
                newName: "EstateId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeImages_HomeId",
                table: "HomeImages",
                newName: "IX_HomeImages_EstateId");

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    NFloor = table.Column<int>(type: "int", nullable: false),
                    NRoom = table.Column<int>(type: "int", nullable: false),
                    NBedroom = table.Column<int>(type: "int", nullable: false),
                    NBath = table.Column<int>(type: "int", nullable: false),
                    NLivingRoom = table.Column<int>(type: "int", nullable: false),
                    NReceptionRoom = table.Column<int>(type: "int", nullable: false),
                    NBalcone = table.Column<int>(type: "int", nullable: false),
                    NGarage = table.Column<int>(type: "int", nullable: false),
                    NKitchen = table.Column<int>(type: "int", nullable: false),
                    NFoodRoom = table.Column<int>(type: "int", nullable: false),
                    NDepot = table.Column<int>(type: "int", nullable: false),
                    Cover = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ExtraFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ForRent = table.Column<bool>(type: "bit", nullable: false),
                    ForSale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HomeImages_Estates_EstateId",
                table: "HomeImages",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeImages_Estates_EstateId",
                table: "HomeImages");

            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.RenameColumn(
                name: "EstateId",
                table: "HomeImages",
                newName: "HomeId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeImages_EstateId",
                table: "HomeImages",
                newName: "IX_HomeImages_HomeId");

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<double>(type: "float", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cover = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ExtraFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForRent = table.Column<bool>(type: "bit", nullable: false),
                    ForSale = table.Column<bool>(type: "bit", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    NBalcone = table.Column<int>(type: "int", nullable: false),
                    NBath = table.Column<int>(type: "int", nullable: false),
                    NBedroom = table.Column<int>(type: "int", nullable: false),
                    NDepot = table.Column<int>(type: "int", nullable: false),
                    NFloor = table.Column<int>(type: "int", nullable: false),
                    NFoodRoom = table.Column<int>(type: "int", nullable: false),
                    NGarage = table.Column<int>(type: "int", nullable: false),
                    NKitchen = table.Column<int>(type: "int", nullable: false),
                    NLivingRoom = table.Column<int>(type: "int", nullable: false),
                    NReceptionRoom = table.Column<int>(type: "int", nullable: false),
                    NRoom = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HomeImages_Homes_HomeId",
                table: "HomeImages",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
