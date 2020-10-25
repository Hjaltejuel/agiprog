using Microsoft.EntityFrameworkCore.Migrations;

namespace agiprog.Migrations
{
    public partial class elv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meetings_roadmaps_RoadmapId",
                table: "meetings");

            migrationBuilder.AlterColumn<int>(
                name: "RoadmapId",
                table: "meetings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_meetings_roadmaps_RoadmapId",
                table: "meetings",
                column: "RoadmapId",
                principalTable: "roadmaps",
                principalColumn: "RoadmapID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meetings_roadmaps_RoadmapId",
                table: "meetings");

            migrationBuilder.AlterColumn<int>(
                name: "RoadmapId",
                table: "meetings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_meetings_roadmaps_RoadmapId",
                table: "meetings",
                column: "RoadmapId",
                principalTable: "roadmaps",
                principalColumn: "RoadmapID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
