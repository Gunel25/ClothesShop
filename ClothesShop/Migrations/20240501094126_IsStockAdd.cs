using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Migrations
{
    /// <inheritdoc />
    public partial class IsStockAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStock",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStock",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsStock",
                table: "Categories");
        }
    }
}
