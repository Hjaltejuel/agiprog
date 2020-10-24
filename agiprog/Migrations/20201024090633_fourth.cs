using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace agiprog.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_steps_roadmaps_RoadmapId",
                table: "steps");

            migrationBuilder.AlterColumn<int>(
                name: "RoadmapId",
                table: "steps",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "steps",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "steps",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "steps",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_steps_roadmaps_RoadmapId",
                table: "steps",
                column: "RoadmapId",
                principalTable: "roadmaps",
                principalColumn: "RoadmapID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_steps_roadmaps_RoadmapId",
                table: "steps");

            migrationBuilder.AlterColumn<int>(
                name: "RoadmapId",
                table: "steps",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "steps",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Img",
                table: "steps",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "steps",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_steps_roadmaps_RoadmapId",
                table: "steps",
                column: "RoadmapId",
                principalTable: "roadmaps",
                principalColumn: "RoadmapID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
