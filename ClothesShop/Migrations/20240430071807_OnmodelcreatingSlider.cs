using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothesShop.Migrations
{
    /// <inheritdoc />
    public partial class OnmodelcreatingSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "ImgUrl", "IsCheck", "Title" },
                values: new object[,]
                {
                    { 1, "Ürünümüz unisex olduğundan kadın ve erkek için uygundur.", "txt", true, "Unisex Oversize Bisiklet Yaka Pamuk Pink Duck Baskılı Kısa Kollu Tişört" },
                    { 2, "Modelin Ölçüleri: Boy: 1.70, Göğüs: 87, Bel: 65, Kalça: 93, Beden:S/34/1 Stüdyo çekimlerinde renkler ışık farklılığından dolayı değişiklik gösterebilir.\r\n", "txt", true, "Kadın Beyaz Beyaz Wave Desen Dik Yaka Uzun Kollu Bluz" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
