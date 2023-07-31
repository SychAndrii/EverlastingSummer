using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerEndings_Endings_EndingId",
                table: "PlayerEndings");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerEndings_Users_UserId",
                table: "PlayerEndings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerEndings",
                table: "PlayerEndings");

            migrationBuilder.RenameTable(
                name: "PlayerEndings",
                newName: "UserEndings");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerEndings_UserId",
                table: "UserEndings",
                newName: "IX_UserEndings_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEndings",
                table: "UserEndings",
                column: "EndingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEndings_Endings_EndingId",
                table: "UserEndings",
                column: "EndingId",
                principalTable: "Endings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEndings_Users_UserId",
                table: "UserEndings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEndings_Endings_EndingId",
                table: "UserEndings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEndings_Users_UserId",
                table: "UserEndings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEndings",
                table: "UserEndings");

            migrationBuilder.RenameTable(
                name: "UserEndings",
                newName: "PlayerEndings");

            migrationBuilder.RenameIndex(
                name: "IX_UserEndings_UserId",
                table: "PlayerEndings",
                newName: "IX_PlayerEndings_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerEndings",
                table: "PlayerEndings",
                column: "EndingId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerEndings_Endings_EndingId",
                table: "PlayerEndings",
                column: "EndingId",
                principalTable: "Endings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerEndings_Users_UserId",
                table: "PlayerEndings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
