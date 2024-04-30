using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Migrations
{
    /// <inheritdoc />
    public partial class SliderDefaultDeger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImgUrl", "IsCheck", "Title" },
                values: new object[] { "cart-item-2.jpg", true, "Oversize Bisiklet Yaka Pamuk Baskılı Kısa Kollu Tişört" });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImgUrl", "IsCheck", "Title" },
                values: new object[] { "cart-item-1.jpg", true, "Kadın Dik Yaka Uzun Kollu Bluz" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImgUrl", "IsCheck", "Title" },
                values: new object[] { "txt", false, "Unisex Oversize Bisiklet Yaka Pamuk Pink Duck Baskılı Kısa Kollu Tişört" });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImgUrl", "IsCheck", "Title" },
                values: new object[] { "txt", false, "Kadın Beyaz Beyaz Wave Desen Dik Yaka Uzun Kollu Bluz" });
        }
    }
}
