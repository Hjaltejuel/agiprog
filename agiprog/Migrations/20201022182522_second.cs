using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace agiprog.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meetings",
                columns: table => new
                {
                    MeetingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    completedSteps = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meetings", x => x.MeetingId);
                });

            migrationBuilder.CreateTable(
                name: "roadmaps",
                columns: table => new
                {
                    RoadmapID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    MeetingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roadmaps", x => x.RoadmapID);
                    table.ForeignKey(
                        name: "FK_roadmaps_meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "steps",
                columns: table => new
                {
                    StepId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    Img = table.Column<byte[]>(nullable: true),
                    RoadmapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_steps", x => x.StepId);
                    table.ForeignKey(
                        name: "FK_steps_roadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "roadmaps",
                        principalColumn: "RoadmapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roadmaps_MeetingId",
                table: "roadmaps",
                column: "MeetingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_steps_RoadmapId",
                table: "steps",
                column: "RoadmapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "steps");

            migrationBuilder.DropTable(
                name: "roadmaps");

            migrationBuilder.DropTable(
                name: "meetings");
        }
    }
}
