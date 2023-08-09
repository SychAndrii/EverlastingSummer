using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class RenamedEndingColumnInStatePointsConditionToState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndingPointsConditions_States_EndingId",
                table: "EndingPointsConditions");

            migrationBuilder.RenameColumn(
                name: "EndingId",
                table: "EndingPointsConditions",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_EndingPointsConditions_EndingId",
                table: "EndingPointsConditions",
                newName: "IX_EndingPointsConditions_StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingPointsConditions_States_StateId",
                table: "EndingPointsConditions",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndingPointsConditions_States_StateId",
                table: "EndingPointsConditions");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "EndingPointsConditions",
                newName: "EndingId");

            migrationBuilder.RenameIndex(
                name: "IX_EndingPointsConditions_StateId",
                table: "EndingPointsConditions",
                newName: "IX_EndingPointsConditions_EndingId");

            migrationBuilder.AddForeignKey(
                name: "FK_EndingPointsConditions_States_EndingId",
                table: "EndingPointsConditions",
                column: "EndingId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
