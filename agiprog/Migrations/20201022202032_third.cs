using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace agiprog.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roadmaps_meetings_MeetingId",
                table: "roadmaps");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingId",
                table: "roadmaps",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingId",
                table: "meetings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_roadmaps_meetings_MeetingId",
                table: "roadmaps",
                column: "MeetingId",
                principalTable: "meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roadmaps_meetings_MeetingId",
                table: "roadmaps");

            migrationBuilder.AlterColumn<int>(
                name: "MeetingId",
                table: "roadmaps",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeetingId",
                table: "meetings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_roadmaps_meetings_MeetingId",
                table: "roadmaps",
                column: "MeetingId",
                principalTable: "meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
