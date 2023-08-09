using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AllowManyTransitionsToOneScene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions",
                column: "TargetSceneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_TargetSceneId",
                table: "Transitions",
                column: "TargetSceneId",
                unique: true);
        }
    }
}
