using Microsoft.EntityFrameworkCore.Migrations;

namespace agiprog.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageBodies_Messages_MessageMeetingId_MessageStepId",
                table: "MessageBodies");

            migrationBuilder.DropIndex(
                name: "IX_MessageBodies_MessageMeetingId_MessageStepId",
                table: "MessageBodies");

            migrationBuilder.DropColumn(
                name: "MessageMeetingId",
                table: "MessageBodies");

            migrationBuilder.DropColumn(
                name: "MessageStepId",
                table: "MessageBodies");

            migrationBuilder.AddColumn<string>(
                name: "MeetingId",
                table: "MessageBodies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "MessageBodies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MessageBodies_MeetingId_StepId",
                table: "MessageBodies",
                columns: new[] { "MeetingId", "StepId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBodies_Messages_MeetingId_StepId",
                table: "MessageBodies",
                columns: new[] { "MeetingId", "StepId" },
                principalTable: "Messages",
                principalColumns: new[] { "MeetingId", "StepId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageBodies_Messages_MeetingId_StepId",
                table: "MessageBodies");

            migrationBuilder.DropIndex(
                name: "IX_MessageBodies_MeetingId_StepId",
                table: "MessageBodies");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "MessageBodies");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "MessageBodies");

            migrationBuilder.AddColumn<string>(
                name: "MessageMeetingId",
                table: "MessageBodies",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageStepId",
                table: "MessageBodies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageBodies_MessageMeetingId_MessageStepId",
                table: "MessageBodies",
                columns: new[] { "MessageMeetingId", "MessageStepId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBodies_Messages_MessageMeetingId_MessageStepId",
                table: "MessageBodies",
                columns: new[] { "MessageMeetingId", "MessageStepId" },
                principalTable: "Messages",
                principalColumns: new[] { "MeetingId", "StepId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
