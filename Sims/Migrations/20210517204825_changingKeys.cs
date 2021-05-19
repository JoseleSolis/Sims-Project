using Microsoft.EntityFrameworkCore.Migrations;

namespace Sims.Migrations
{
    public partial class changingKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionUpgradesSkill",
                table: "ProfessionUpgradesSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NeighborhoodUpgradesSkill",
                table: "NeighborhoodUpgradesSkill");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionUpgradesSkill",
                table: "ProfessionUpgradesSkill",
                column: "ProfessionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NeighborhoodUpgradesSkill",
                table: "NeighborhoodUpgradesSkill",
                column: "NeighborhoodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionUpgradesSkill",
                table: "ProfessionUpgradesSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NeighborhoodUpgradesSkill",
                table: "NeighborhoodUpgradesSkill");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionUpgradesSkill",
                table: "ProfessionUpgradesSkill",
                columns: new[] { "ProfessionID", "SkillID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_NeighborhoodUpgradesSkill",
                table: "NeighborhoodUpgradesSkill",
                columns: new[] { "NeighborhoodID", "SkillID" });
        }
    }
}
