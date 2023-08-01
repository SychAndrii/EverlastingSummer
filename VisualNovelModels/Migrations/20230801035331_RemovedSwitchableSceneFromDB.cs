using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSwitchableSceneFromDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transitions_SwitchableSceneId",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "SwitchableSceneId",
                table: "Transitions");

            migrationBuilder.RenameColumn(
                name: "SwitchableSceneId",
                table: "SpriteCharacters",
                newName: "SceneId");

            migrationBuilder.RenameIndex(
                name: "IX_SpriteCharacters_SwitchableSceneId",
                table: "SpriteCharacters",
                newName: "IX_SpriteCharacters_SceneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SceneId",
                table: "SpriteCharacters",
                newName: "SwitchableSceneId");

            migrationBuilder.RenameIndex(
                name: "IX_SpriteCharacters_SceneId",
                table: "SpriteCharacters",
                newName: "IX_SpriteCharacters_SwitchableSceneId");

            migrationBuilder.AddColumn<Guid>(
                name: "SwitchableSceneId",
                table: "Transitions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_SwitchableSceneId",
                table: "Transitions",
                column: "SwitchableSceneId");
        }
    }
}
