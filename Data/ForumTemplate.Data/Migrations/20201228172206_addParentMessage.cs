using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumTemplate.Data.Migrations
{
    public partial class addParentMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentMessage",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentMessage",
                table: "Messages");
        }
    }
}
