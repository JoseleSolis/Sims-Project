using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sims.Migrations
{
    public partial class correctingKeysInlast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NeighborhoodUpgradesSkill",
                columns: table => new
                {
                    NeighborhoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighborhoodUpgradesSkill", x => new { x.NeighborhoodID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_NeighborhoodUpgradesSkill_Neighborhoods_NeighborhoodID",
                        column: x => x.NeighborhoodID,
                        principalTable: "Neighborhoods",
                        principalColumn: "NeighborhoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NeighborhoodUpgradesSkill_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NeighborhoodUpgradesSkill_SkillID",
                table: "NeighborhoodUpgradesSkill",
                column: "SkillID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NeighborhoodUpgradesSkill");
        }
    }
}
