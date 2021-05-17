using Microsoft.EntityFrameworkCore.Migrations;

namespace Sims.Migrations
{
    public partial class DescriptionQuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Quests",
                type: "nvarchar(127)",
                maxLength: 127,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Quests");
        }
    }
}
