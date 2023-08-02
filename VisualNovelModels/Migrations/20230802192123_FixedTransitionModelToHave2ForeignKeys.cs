using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class FixedTransitionModelToHave2ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions");

            migrationBuilder.AddColumn<Guid>(
                name: "SourceSceneId",
                table: "Transitions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_SourceSceneId",
                table: "Transitions",
                column: "SourceSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions",
                column: "TargetSceneId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transitions_SourceSceneId",
                table: "Transitions");

            migrationBuilder.DropIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "SourceSceneId",
                table: "Transitions");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions",
                column: "TargetSceneId");
        }
    }
}
