using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FureverHome.Migrations
{
    /// <inheritdoc />
    public partial class Configuredbrelationshipbetweenmessageandregistereduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RegisteredUserId",
                table: "Messages");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RegisteredUserId",
                table: "Messages",
                column: "RegisteredUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RegisteredUserId",
                table: "Messages");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RegisteredUserId",
                table: "Messages",
                column: "RegisteredUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
