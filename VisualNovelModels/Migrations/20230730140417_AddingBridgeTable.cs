using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddingBridgeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MadeChoicesConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MadeChoicesConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceMadeChoicesCondition",
                columns: table => new
                {
                    ChoicesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MadeChoicesConditionsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceMadeChoicesCondition", x => new { x.ChoicesId, x.MadeChoicesConditionsId });
                    table.ForeignKey(
                        name: "FK_ChoiceMadeChoicesCondition_Choices_ChoicesId",
                        column: x => x.ChoicesId,
                        principalTable: "Choices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceMadeChoicesCondition_MadeChoicesConditions_MadeChoicesConditionsId",
                        column: x => x.MadeChoicesConditionsId,
                        principalTable: "MadeChoicesConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceMadeChoicesCondition_MadeChoicesConditionsId",
                table: "ChoiceMadeChoicesCondition",
                column: "MadeChoicesConditionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoiceMadeChoicesCondition");

            migrationBuilder.DropTable(
                name: "MadeChoicesConditions");
        }
    }
}
