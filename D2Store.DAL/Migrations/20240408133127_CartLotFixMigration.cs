using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D2Store.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CartLotFixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedPrice",
                table: "CartLots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ExpectedPrice",
                table: "CartLots",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
