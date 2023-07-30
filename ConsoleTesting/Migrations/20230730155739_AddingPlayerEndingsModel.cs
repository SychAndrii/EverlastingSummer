using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddingPlayerEndingsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerEndings",
                columns: table => new
                {
                    EndingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CurrentPoints = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerEndings", x => x.EndingId);
                    table.ForeignKey(
                        name: "FK_PlayerEndings_Endings_EndingId",
                        column: x => x.EndingId,
                        principalTable: "Endings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerEndings");
        }
    }
}
