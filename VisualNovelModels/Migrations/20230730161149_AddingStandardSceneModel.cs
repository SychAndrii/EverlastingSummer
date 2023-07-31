using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddingStandardSceneModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StandardSceneId",
                table: "Transitions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StandardScenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Dialogue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardScenes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_StandardSceneId",
                table: "Transitions",
                column: "StandardSceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transitions_StandardScenes_StandardSceneId",
                table: "Transitions",
                column: "StandardSceneId",
                principalTable: "StandardScenes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transitions_StandardScenes_StandardSceneId",
                table: "Transitions");

            migrationBuilder.DropTable(
                name: "StandardScenes");

            migrationBuilder.DropIndex(
                name: "IX_Transitions_StandardSceneId",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "StandardSceneId",
                table: "Transitions");
        }
    }
}
