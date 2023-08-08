using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserModelToIncludeManyUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_Choices_ChoiceId",
                table: "EndingModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_EndingModifiers_States_StateId",
                table: "EndingModifiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EndingModifiers",
                table: "EndingModifiers");

            migrationBuilder.RenameTable(
                name: "EndingModifiers",
                newName: "StateModifiers");

            migrationBuilder.RenameIndex(
                name: "IX_EndingModifiers_StateId",
                table: "StateModifiers",
                newName: "IX_StateModifiers_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_EndingModifiers_ChoiceId",
                table: "StateModifiers",
                newName: "IX_StateModifiers_ChoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StateModifiers",
                table: "StateModifiers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StateModifiers_Choices_ChoiceId",
                table: "StateModifiers",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StateModifiers_States_StateId",
                table: "StateModifiers",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateModifiers_Choices_ChoiceId",
                table: "StateModifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_StateModifiers_States_StateId",
                table: "StateModifiers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StateModifiers",
                table: "StateModifiers");

            migrationBuilder.RenameTable(
                name: "StateModifiers",
                newName: "EndingModifiers");

            migrationBuilder.RenameIndex(
                name: "IX_StateModifiers_StateId",
                table: "EndingModifiers",
                newName: "IX_EndingModifiers_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_StateModifiers_ChoiceId",
                table: "EndingModifiers",
                newName: "IX_EndingModifiers_ChoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EndingModifiers",
                table: "EndingModifiers",
                column: "Id");

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
    }
}
