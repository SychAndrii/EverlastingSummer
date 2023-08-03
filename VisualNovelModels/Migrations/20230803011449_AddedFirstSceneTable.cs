using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddedFirstSceneTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstScene",
                columns: table => new
                {
                    Id = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    SceneId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstScene", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstScene_SceneId",
                table: "FirstScene",
                column: "SceneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstScene");
        }
    }
}
