using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class MovedCharactersFieldToSwitchableScene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceSceneSpriteCharacter_ChoiceScenesId",
                table: "ChoiceSceneSpriteCharacter",
                column: "ChoiceScenesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoiceSceneSpriteCharacter");
        }
    }
}
