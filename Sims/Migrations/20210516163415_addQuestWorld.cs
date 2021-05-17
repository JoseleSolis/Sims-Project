using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sims.Migrations
{
    public partial class addQuestWorld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestWorld",
                columns: table => new
                {
                    QuestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorldID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestWorld", x => x.QuestID);
                    table.ForeignKey(
                        name: "FK_QuestWorld_Quests_QuestID",
                        column: x => x.QuestID,
                        principalTable: "Quests",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestWorld_Worlds_WorldID",
                        column: x => x.WorldID,
                        principalTable: "Worlds",
                        principalColumn: "WorldID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestWorld_WorldID",
                table: "QuestWorld",
                column: "WorldID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestWorld");
        }
    }
}
