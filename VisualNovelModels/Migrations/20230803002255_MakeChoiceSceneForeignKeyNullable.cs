﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTesting.Migrations
{
    /// <inheritdoc />
    public partial class MakeChoiceSceneForeignKeyNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_ChoiceScenes_ChoiceSceneId",
                table: "Choices");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChoiceSceneId",
                table: "Choices",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_ChoiceScenes_ChoiceSceneId",
                table: "Choices",
                column: "ChoiceSceneId",
                principalTable: "ChoiceScenes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_ChoiceScenes_ChoiceSceneId",
                table: "Choices");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChoiceSceneId",
                table: "Choices",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_ChoiceScenes_ChoiceSceneId",
                table: "Choices",
                column: "ChoiceSceneId",
                principalTable: "ChoiceScenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
