using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpriteCharactersSceneModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_States_EndingId",
                table: "EndingModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_Transitions_TransitionId",
                table: "EndingModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_Users_UserId",
                table: "EndingModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_SceneColors_Sequences_SequenceId",
                table: "SceneColors");

            migrationBuilder.DropTable(
                name: "Sequences");

            migrationBuilder.DropIndex(
                name: "IX_EndingModifiers_EndingId",
                table: "EndingModifiers");

            migrationBuilder.DropColumn(
                name: "EndingId",
                table: "EndingModifiers");

            migrationBuilder.RenameColumn(
                name: "SceneId",
                table: "SpriteCharacters",
                newName: "SpriteCharactersSceneId");

            migrationBuilder.RenameIndex(
                name: "IX_SpriteCharacters_SceneId",
                table: "SpriteCharacters",
                newName: "IX_SpriteCharacters_SpriteCharactersSceneId");

            migrationBuilder.RenameColumn(
                name: "SequenceId",
                table: "SceneColors",
                newName: "SceneId");

            migrationBuilder.RenameIndex(
                name: "IX_SceneColors_SequenceId",
                table: "SceneColors",
                newName: "IX_SceneColors_SceneId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EndingModifiers",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "TransitionId",
                table: "EndingModifiers",
                newName: "ChoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_EndingModifiers_UserId",
                table: "EndingModifiers",
                newName: "IX_EndingModifiers_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_EndingModifiers_TransitionId",
                table: "EndingModifiers",
                newName: "IX_EndingModifiers_ChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingModifiers_Choices_ChoiceId",
                table: "EndingModifiers",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingModifiers_States_StateId",
                table: "EndingModifiers",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_Choices_ChoiceId",
                table: "EndingModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_States_StateId",
                table: "EndingModifiers");

            migrationBuilder.RenameColumn(
                name: "SpriteCharactersSceneId",
                table: "SpriteCharacters",
                newName: "SceneId");

            migrationBuilder.RenameIndex(
                name: "IX_SpriteCharacters_SpriteCharactersSceneId",
                table: "SpriteCharacters",
                newName: "IX_SpriteCharacters_SceneId");

            migrationBuilder.RenameColumn(
                name: "SceneId",
                table: "SceneColors",
                newName: "SequenceId");

            migrationBuilder.RenameIndex(
                name: "IX_SceneColors_SceneId",
                table: "SceneColors",
                newName: "IX_SceneColors_SequenceId");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "EndingModifiers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ChoiceId",
                table: "EndingModifiers",
                newName: "TransitionId");

            migrationBuilder.RenameIndex(
                name: "IX_EndingModifiers_StateId",
                table: "EndingModifiers",
                newName: "IX_EndingModifiers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EndingModifiers_ChoiceId",
                table: "EndingModifiers",
                newName: "IX_EndingModifiers_TransitionId");

            migrationBuilder.AddColumn<Guid>(
                name: "EndingId",
                table: "EndingModifiers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Sequences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransitionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sequences_Transitions_TransitionId",
                        column: x => x.TransitionId,
                        principalTable: "Transitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EndingModifiers_EndingId",
                table: "EndingModifiers",
                column: "EndingId");

            migrationBuilder.CreateIndex(
                name: "IX_Sequences_TransitionId",
                table: "Sequences",
                column: "TransitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingModifiers_States_EndingId",
                table: "EndingModifiers",
                column: "EndingId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndingModifiers_Transitions_TransitionId",
                table: "EndingModifiers",
                column: "TransitionId",
                principalTable: "Transitions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingModifiers_Users_UserId",
                table: "EndingModifiers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SceneColors_Sequences_SequenceId",
                table: "SceneColors",
                column: "SequenceId",
                principalTable: "Sequences",
                principalColumn: "Id");
        }
    }
}
