using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Migrations
{
    /// <inheritdoc />
    public partial class TrueUserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgramUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProgramUserId",
                table: "Orders",
                column: "ProgramUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ProgramUserId",
                table: "Orders",
                column: "ProgramUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ProgramUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProgramUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProgramUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
