using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D2Store.Migrations
{
    /// <inheritdoc />
    public partial class AddHeroesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Items",
                newName: "HeroId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "Clients",
                newName: "UserId");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Lots",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "HeroId",
                table: "Items",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Clients",
                newName: "IdentityId");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }
    }
}
