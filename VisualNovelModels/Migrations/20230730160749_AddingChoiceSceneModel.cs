using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddingChoiceSceneModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TransitionId",
                table: "MadeChoicesConditions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransitionId",
                table: "EndingPointsConditions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChoiceSceneId",
                table: "Choices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChoiceScenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceScenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TargetSceneId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChoiceSceneId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transitions_ChoiceScenes_ChoiceSceneId",
                        column: x => x.ChoiceSceneId,
                        principalTable: "ChoiceScenes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MadeChoicesConditions_TransitionId",
                table: "MadeChoicesConditions",
                column: "TransitionId");

            migrationBuilder.CreateIndex(
                name: "IX_EndingPointsConditions_TransitionId",
                table: "EndingPointsConditions",
                column: "TransitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_ChoiceSceneId",
                table: "Choices",
                column: "ChoiceSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_ChoiceSceneId",
                table: "Transitions",
                column: "ChoiceSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions",
                column: "TargetSceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_ChoiceScenes_ChoiceSceneId",
                table: "Choices",
                column: "ChoiceSceneId",
                principalTable: "ChoiceScenes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingPointsConditions_Transitions_TransitionId",
                table: "EndingPointsConditions",
                column: "TransitionId",
                principalTable: "Transitions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MadeChoicesConditions_Transitions_TransitionId",
                table: "MadeChoicesConditions",
                column: "TransitionId",
                principalTable: "Transitions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_ChoiceScenes_ChoiceSceneId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingPointsConditions_Transitions_TransitionId",
                table: "EndingPointsConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_MadeChoicesConditions_Transitions_TransitionId",
                table: "MadeChoicesConditions");

            migrationBuilder.DropTable(
                name: "Transitions");

            migrationBuilder.DropTable(
                name: "ChoiceScenes");

            migrationBuilder.DropIndex(
                name: "IX_MadeChoicesConditions_TransitionId",
                table: "MadeChoicesConditions");

            migrationBuilder.DropIndex(
                name: "IX_EndingPointsConditions_TransitionId",
                table: "EndingPointsConditions");

            migrationBuilder.DropIndex(
                name: "IX_Choices_ChoiceSceneId",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "TransitionId",
                table: "MadeChoicesConditions");

            migrationBuilder.DropColumn(
                name: "TransitionId",
                table: "EndingPointsConditions");

            migrationBuilder.DropColumn(
                name: "ChoiceSceneId",
                table: "Choices");
        }
    }
}
