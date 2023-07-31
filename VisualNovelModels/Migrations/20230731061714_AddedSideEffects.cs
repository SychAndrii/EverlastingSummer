using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddedSideEffects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PlayerEndings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Choices",
                type: "TEXT",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SceneColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SequenceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceneColors_Sequences_SequenceId",
                        column: x => x.SequenceId,
                        principalTable: "Sequences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EndingModifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransitionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EndingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndingModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndingModifiers_Endings_EndingId",
                        column: x => x.EndingId,
                        principalTable: "Endings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndingModifiers_Transitions_TransitionId",
                        column: x => x.TransitionId,
                        principalTable: "Transitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EndingModifiers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerEndings_UserId",
                table: "PlayerEndings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_UserId",
                table: "Choices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EndingModifiers_EndingId",
                table: "EndingModifiers",
                column: "EndingId");

            migrationBuilder.CreateIndex(
                name: "IX_EndingModifiers_TransitionId",
                table: "EndingModifiers",
                column: "TransitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EndingModifiers_UserId",
                table: "EndingModifiers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneColors_SequenceId",
                table: "SceneColors",
                column: "SequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sequences_TransitionId",
                table: "Sequences",
                column: "TransitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Users_UserId",
                table: "Choices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerEndings_Users_UserId",
                table: "PlayerEndings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Users_UserId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerEndings_Users_UserId",
                table: "PlayerEndings");

            migrationBuilder.DropTable(
                name: "EndingModifiers");

            migrationBuilder.DropTable(
                name: "SceneColors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sequences");

            migrationBuilder.DropIndex(
                name: "IX_PlayerEndings_UserId",
                table: "PlayerEndings");

            migrationBuilder.DropIndex(
                name: "IX_Choices_UserId",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PlayerEndings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Choices");
        }
    }
}
