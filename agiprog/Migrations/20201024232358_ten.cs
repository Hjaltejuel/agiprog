using Microsoft.EntityFrameworkCore.Migrations;

namespace agiprog.Migrations
{
    public partial class ten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roadmaps_meetings_MeetingId",
                table: "roadmaps");

            migrationBuilder.DropForeignKey(
                name: "FK_steps_roadmaps_RoadmapId",
                table: "steps");

            migrationBuilder.DropIndex(
                name: "IX_steps_RoadmapId",
                table: "steps");

            migrationBuilder.DropIndex(
                name: "IX_roadmaps_MeetingId",
                table: "roadmaps");

            migrationBuilder.DropColumn(
                name: "RoadmapId",
                table: "steps");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "roadmaps");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "meetings",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoadmapId",
                table: "meetings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoadmapSteps",
                columns: table => new
                {
                    RoadmapId = table.Column<int>(nullable: false),
                    StepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapSteps", x => new { x.RoadmapId, x.StepId });
                    table.ForeignKey(
                        name: "FK_RoadmapSteps_roadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "roadmaps",
                        principalColumn: "RoadmapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadmapSteps_steps_StepId",
                        column: x => x.StepId,
                        principalTable: "steps",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_meetings_RoadmapId",
                table: "meetings",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapSteps_StepId",
                table: "RoadmapSteps",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_meetings_roadmaps_RoadmapId",
                table: "meetings",
                column: "RoadmapId",
                principalTable: "roadmaps",
                principalColumn: "RoadmapID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meetings_roadmaps_RoadmapId",
                table: "meetings");

            migrationBuilder.DropTable(
                name: "RoadmapSteps");

            migrationBuilder.DropIndex(
                name: "IX_meetings_RoadmapId",
                table: "meetings");

            migrationBuilder.DropColumn(
                name: "RoadmapId",
                table: "meetings");

            migrationBuilder.AddColumn<int>(
                name: "RoadmapId",
                table: "steps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingId",
                table: "roadmaps",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "meetings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_steps_RoadmapId",
                table: "steps",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_roadmaps_MeetingId",
                table: "roadmaps",
                column: "MeetingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_roadmaps_meetings_MeetingId",
                table: "roadmaps",
                column: "MeetingId",
                principalTable: "meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_steps_roadmaps_RoadmapId",
                table: "steps",
                column: "RoadmapId",
                principalTable: "roadmaps",
                principalColumn: "RoadmapID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
