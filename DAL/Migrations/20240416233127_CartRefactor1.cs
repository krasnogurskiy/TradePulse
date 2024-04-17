using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CartRefactor1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CartsProducts_UserId",
                table: "CartsProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartsProducts_Users_UserId",
                table: "CartsProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartsProducts_Users_UserId",
                table: "CartsProducts");

            migrationBuilder.DropIndex(
                name: "IX_CartsProducts_UserId",
                table: "CartsProducts");
        }
    }
}
