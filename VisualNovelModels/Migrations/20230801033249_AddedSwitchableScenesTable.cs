using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddedSwitchableScenesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_ChoiceScenes_ChoiceSceneId",
                table: "Transitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_StandardScenes_StandardSceneId",
                table: "Transitions");

            migrationBuilder.DropTable(
                name: "ChoiceSceneSpriteCharacter");

            migrationBuilder.DropTable(
                name: "SpriteCharacterStandardScene");

            migrationBuilder.DropIndex(
                name: "IX_Transitions_ChoiceSceneId",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "ChoiceSceneId",
                table: "Transitions");

            migrationBuilder.RenameColumn(
                name: "StandardSceneId",
                table: "Transitions",
                newName: "SwitchableSceneId");

            migrationBuilder.RenameIndex(
                name: "IX_Transitions_StandardSceneId",
                table: "Transitions",
                newName: "IX_Transitions_SwitchableSceneId");

            migrationBuilder.AddColumn<Guid>(
                name: "SpriteCharacterId",
                table: "StandardScenes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SwitchableSceneId",
                table: "SpriteCharacters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpriteCharacterId",
                table: "ChoiceScenes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StandardScenes_SpriteCharacterId",
                table: "StandardScenes",
                column: "SpriteCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SpriteCharacters_SwitchableSceneId",
                table: "SpriteCharacters",
                column: "SwitchableSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceScenes_SpriteCharacterId",
                table: "ChoiceScenes",
                column: "SpriteCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceScenes_SpriteCharacters_SpriteCharacterId",
                table: "ChoiceScenes",
                column: "SpriteCharacterId",
                principalTable: "SpriteCharacters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardScenes_SpriteCharacters_SpriteCharacterId",
                table: "StandardScenes",
                column: "SpriteCharacterId",
                principalTable: "SpriteCharacters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceScenes_SpriteCharacters_SpriteCharacterId",
                table: "ChoiceScenes");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardScenes_SpriteCharacters_SpriteCharacterId",
                table: "StandardScenes");

            migrationBuilder.DropIndex(
                name: "IX_StandardScenes_SpriteCharacterId",
                table: "StandardScenes");

            migrationBuilder.DropIndex(
                name: "IX_SpriteCharacters_SwitchableSceneId",
                table: "SpriteCharacters");

            migrationBuilder.DropIndex(
                name: "IX_ChoiceScenes_SpriteCharacterId",
                table: "ChoiceScenes");

            migrationBuilder.DropColumn(
                name: "SpriteCharacterId",
                table: "StandardScenes");

            migrationBuilder.DropColumn(
                name: "SwitchableSceneId",
                table: "SpriteCharacters");

            migrationBuilder.DropColumn(
                name: "SpriteCharacterId",
                table: "ChoiceScenes");

            migrationBuilder.RenameColumn(
                name: "SwitchableSceneId",
                table: "Transitions",
                newName: "StandardSceneId");

            migrationBuilder.RenameIndex(
                name: "IX_Transitions_SwitchableSceneId",
                table: "Transitions",
                newName: "IX_Transitions_StandardSceneId");

            migrationBuilder.AddColumn<Guid>(
                name: "ChoiceSceneId",
                table: "Transitions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChoiceSceneSpriteCharacter",
                columns: table => new
                {
                    CharactersId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChoiceScenesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceSceneSpriteCharacter", x => new { x.CharactersId, x.ChoiceScenesId });
                    table.ForeignKey(
                        name: "FK_ChoiceSceneSpriteCharacter_ChoiceScenes_ChoiceScenesId",
                        column: x => x.ChoiceScenesId,
                        principalTable: "ChoiceScenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceSceneSpriteCharacter_SpriteCharacters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "SpriteCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Transitions_ChoiceSceneId",
                table: "Transitions",
                column: "ChoiceSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceSceneSpriteCharacter_ChoiceScenesId",
                table: "ChoiceSceneSpriteCharacter",
                column: "ChoiceScenesId");

            migrationBuilder.CreateIndex(
                name: "IX_SpriteCharacterStandardScene_StandardScenesId",
                table: "SpriteCharacterStandardScene",
                column: "StandardScenesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_ChoiceScenes_ChoiceSceneId",
                table: "Transitions",
                column: "ChoiceSceneId",
                principalTable: "ChoiceScenes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_StandardScenes_StandardSceneId",
                table: "Transitions",
                column: "StandardSceneId",
                principalTable: "StandardScenes",
                principalColumn: "Id");
        }
    }
}
