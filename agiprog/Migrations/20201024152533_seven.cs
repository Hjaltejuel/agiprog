using Microsoft.EntityFrameworkCore.Migrations;

namespace agiprog.Migrations
{
    public partial class seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "completedSteps",
                table: "meetings",
                newName: "CompletedSteps");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "meetings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "meetings");

            migrationBuilder.RenameColumn(
                name: "CompletedSteps",
                table: "meetings",
                newName: "completedSteps");
        }
    }
}
