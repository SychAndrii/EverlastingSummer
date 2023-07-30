using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddedEndingPointsConditionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EndingPointsConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PointsRequired = table.Column<int>(type: "INTEGER", nullable: false),
                    EndingId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndingPointsConditions", x => x.Id);
                    table.CheckConstraint("Points_bigger_than_0", "PointsRequired > 0");
                    table.ForeignKey(
                        name: "FK_EndingPointsConditions_Endings_EndingId",
                        column: x => x.EndingId,
                        principalTable: "Endings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EndingPointsConditions_EndingId",
                table: "EndingPointsConditions",
                column: "EndingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndingPointsConditions");
        }
    }
}
