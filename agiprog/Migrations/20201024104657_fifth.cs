using Microsoft.EntityFrameworkCore.Migrations;

namespace agiprog.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "roadmaps",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "roadmaps",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "roadmaps",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "roadmaps",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "roadmaps");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "roadmaps");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roadmaps",
                newName: "name");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "roadmaps",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
