using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddedCharacterAndDialogueModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dialogue",
                table: "StandardScenes",
                newName: "DialogueId");

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
                name: "Dialogues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dialogues_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardScenes_DialogueId",
                table: "StandardScenes",
                column: "DialogueId");

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
                name: "IX_Dialogues_CharacterId",
                table: "Dialogues",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardScenes_Dialogues_DialogueId",
                table: "StandardScenes",
                column: "DialogueId",
                principalTable: "Dialogues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardScenes_Dialogues_DialogueId",
                table: "StandardScenes");

            migrationBuilder.DropTable(
                name: "Dialogues");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_StandardScenes_DialogueId",
                table: "StandardScenes");

            migrationBuilder.RenameColumn(
                name: "DialogueId",
                table: "StandardScenes",
                newName: "Dialogue");
        }
    }
}
