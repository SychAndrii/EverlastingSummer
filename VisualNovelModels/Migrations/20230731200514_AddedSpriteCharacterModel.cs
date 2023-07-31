using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpriteCharacterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogues_Characters_CharacterId",
                table: "Dialogues");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_Endings_EndingId",
                table: "EndingModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingPointsConditions_Endings_EndingId",
                table: "EndingPointsConditions");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "UserEndings");

            migrationBuilder.DropTable(
                name: "Endings");

            migrationBuilder.CreateTable(
                name: "DialogueCharacters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogueCharacters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpriteCharacters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SpritePath = table.Column<string>(type: "TEXT", nullable: false),
                    StandardSceneId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpriteCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpriteCharacters_StandardScenes_StandardSceneId",
                        column: x => x.StandardSceneId,
                        principalTable: "StandardScenes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStates",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CurrentPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStates", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_UserStates_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DialogueCharacters_Name",
                table: "DialogueCharacters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpriteCharacters_SpritePath",
                table: "SpriteCharacters",
                column: "SpritePath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpriteCharacters_StandardSceneId",
                table: "SpriteCharacters",
                column: "StandardSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Name",
                table: "States",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStates_UserId",
                table: "UserStates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogues_DialogueCharacters_CharacterId",
                table: "Dialogues",
                column: "CharacterId",
                principalTable: "DialogueCharacters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingModifiers_States_EndingId",
                table: "EndingModifiers",
                column: "EndingId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndingPointsConditions_States_EndingId",
                table: "EndingPointsConditions",
                column: "EndingId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogues_DialogueCharacters_CharacterId",
                table: "Dialogues");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_States_EndingId",
                table: "EndingModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingPointsConditions_States_EndingId",
                table: "EndingPointsConditions");

            migrationBuilder.DropTable(
                name: "DialogueCharacters");

            migrationBuilder.DropTable(
                name: "SpriteCharacters");

            migrationBuilder.DropTable(
                name: "UserStates");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StandardSceneId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_StandardScenes_StandardSceneId",
                        column: x => x.StandardSceneId,
                        principalTable: "StandardScenes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Endings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEndings",
                columns: table => new
                {
                    EndingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CurrentPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEndings", x => x.EndingId);
                    table.ForeignKey(
                        name: "FK_UserEndings_Endings_EndingId",
                        column: x => x.EndingId,
                        principalTable: "Endings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEndings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Name",
                table: "Characters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StandardSceneId",
                table: "Characters",
                column: "StandardSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_Endings_Name",
                table: "Endings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEndings_UserId",
                table: "UserEndings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogues_Characters_CharacterId",
                table: "Dialogues",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingModifiers_Endings_EndingId",
                table: "EndingModifiers",
                column: "EndingId",
                principalTable: "Endings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndingPointsConditions_Endings_EndingId",
                table: "EndingPointsConditions",
                column: "EndingId",
                principalTable: "Endings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
