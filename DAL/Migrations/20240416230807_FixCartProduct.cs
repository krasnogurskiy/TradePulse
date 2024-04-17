using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixCartProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartsProducts_Carts_ProductId",
                table: "CartsProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CartsProducts_Products_ProductId",
                table: "CartsProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartsProducts_Products_ProductId",
                table: "CartsProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CartsProducts_Carts_ProductId",
                table: "CartsProducts",
                column: "ProductId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
