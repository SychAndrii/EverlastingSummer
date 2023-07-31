using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddedManyToManyRelationshipBetweenCharacterSpritesAndStandardScenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpriteCharacters_StandardScenes_StandardSceneId",
                table: "SpriteCharacters");

            migrationBuilder.DropIndex(
                name: "IX_SpriteCharacters_StandardSceneId",
                table: "SpriteCharacters");

            migrationBuilder.DropColumn(
                name: "StandardSceneId",
                table: "SpriteCharacters");

            migrationBuilder.CreateTable(
                name: "SpriteCharacterStandardScene",
                columns: table => new
                {
                    CharactersId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StandardScenesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpriteCharacterStandardScene", x => new { x.CharactersId, x.StandardScenesId });
                    table.ForeignKey(
                        name: "FK_SpriteCharacterStandardScene_SpriteCharacters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "SpriteCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpriteCharacterStandardScene_StandardScenes_StandardScenesId",
                        column: x => x.StandardScenesId,
                        principalTable: "StandardScenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpriteCharacterStandardScene_StandardScenesId",
                table: "SpriteCharacterStandardScene",
                column: "StandardScenesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpriteCharacterStandardScene");

            migrationBuilder.AddColumn<Guid>(
                name: "StandardSceneId",
                table: "SpriteCharacters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpriteCharacters_StandardSceneId",
                table: "SpriteCharacters",
                column: "StandardSceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpriteCharacters_StandardScenes_StandardSceneId",
                table: "SpriteCharacters",
                column: "StandardSceneId",
                principalTable: "StandardScenes",
                principalColumn: "Id");
        }
    }
}
