using Microsoft.EntityFrameworkCore.Migrations;

namespace Sims.Migrations
{
    public partial class addingInvolveOutcome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "Involvements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Success",
                table: "Involvements");
        }
    }
}
