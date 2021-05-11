using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sims.Migrations
{
    public partial class addingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityImprovesSkill",
                columns: table => new
                {
                    ActivityID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityImprovesSkill", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_ActivityImprovesSkill_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityImprovesSkill_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomesticUnits",
                columns: table => new
                {
                    DomesticUnitID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    BathroomNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomesticUnits", x => x.DomesticUnitID);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    NeighborhoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.NeighborhoodID);
                });

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    SimID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastPerform = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => new { x.SimID, x.ActivityID });
                    table.ForeignKey(
                        name: "FK_Performances_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performances_Sims_SimID",
                        column: x => x.SimID,
                        principalTable: "Sims",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    TypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceID);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProfessionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    BasicSalary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionID);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    QuestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Reward = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.QuestID);
                });

            migrationBuilder.CreateTable(
                name: "SimSkills",
                columns: table => new
                {
                    SimID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimSkills", x => new { x.SimID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_SimSkills_Sims_SimID",
                        column: x => x.SimID,
                        principalTable: "Sims",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worlds",
                columns: table => new
                {
                    WorldID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds", x => x.WorldID);
                });

            migrationBuilder.CreateTable(
                name: "SimLives",
                columns: table => new
                {
                    SimID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DomesticUnitID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimLives", x => x.SimID);
                    table.ForeignKey(
                        name: "FK_SimLives_DomesticUnits_DomesticUnitID",
                        column: x => x.DomesticUnitID,
                        principalTable: "DomesticUnits",
                        principalColumn: "DomesticUnitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimLives_Sims_SimID",
                        column: x => x.SimID,
                        principalTable: "Sims",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NeighborhoodDomesticUnits",
                columns: table => new
                {
                    DomesticUnitID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeighborhoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighborhoodDomesticUnits", x => x.DomesticUnitID);
                    table.ForeignKey(
                        name: "FK_NeighborhoodDomesticUnits_DomesticUnits_DomesticUnitID",
                        column: x => x.DomesticUnitID,
                        principalTable: "DomesticUnits",
                        principalColumn: "DomesticUnitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NeighborhoodDomesticUnits_Neighborhoods_NeighborhoodID",
                        column: x => x.NeighborhoodID,
                        principalTable: "Neighborhoods",
                        principalColumn: "NeighborhoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetID);
                    table.ForeignKey(
                        name: "FK_Pets_PetTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "PetTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NeighborhoodPlaces",
                columns: table => new
                {
                    PlaceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeighborhoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighborhoodPlaces", x => x.PlaceID);
                    table.ForeignKey(
                        name: "FK_NeighborhoodPlaces_Neighborhoods_NeighborhoodID",
                        column: x => x.NeighborhoodID,
                        principalTable: "Neighborhoods",
                        principalColumn: "NeighborhoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NeighborhoodPlaces_Places_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Places",
                        principalColumn: "PlaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    SimID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.SimID);
                    table.ForeignKey(
                        name: "FK_Exercises_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ProfessionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_Sims_SimID",
                        column: x => x.SimID,
                        principalTable: "Sims",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionUpgradesSkill",
                columns: table => new
                {
                    ProfessionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionUpgradesSkill", x => new { x.ProfessionID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_ProfessionUpgradesSkill_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ProfessionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionUpgradesSkill_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestRequiresSkill",
                columns: table => new
                {
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequiredPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestRequiresSkill", x => new { x.SkillID, x.QuestID });
                    table.ForeignKey(
                        name: "FK_QuestRequiresSkill_Quests_QuestID",
                        column: x => x.QuestID,
                        principalTable: "Quests",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestRequiresSkill_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SimID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorldID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => new { x.SimID, x.WorldID, x.Date });
                    table.ForeignKey(
                        name: "FK_Travels_Sims_SimID",
                        column: x => x.SimID,
                        principalTable: "Sims",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Travels_Worlds_WorldID",
                        column: x => x.WorldID,
                        principalTable: "Worlds",
                        principalColumn: "WorldID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetLives",
                columns: table => new
                {
                    PetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DomesticUnitID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetLives", x => x.PetID);
                    table.ForeignKey(
                        name: "FK_PetLives_DomesticUnits_DomesticUnitID",
                        column: x => x.DomesticUnitID,
                        principalTable: "DomesticUnits",
                        principalColumn: "DomesticUnitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetLives_Pets_PetID",
                        column: x => x.PetID,
                        principalTable: "Pets",
                        principalColumn: "PetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Involvements",
                columns: table => new
                {
                    QuestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SimID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorldID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Involvements", x => new { x.SimID, x.Date, x.QuestID, x.WorldID });
                    table.ForeignKey(
                        name: "FK_Involvements_Quests_QuestID",
                        column: x => x.QuestID,
                        principalTable: "Quests",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Involvements_Travels_SimID_WorldID_Date",
                        columns: x => new { x.SimID, x.WorldID, x.Date },
                        principalTable: "Travels",
                        principalColumns: new[] { "SimID", "WorldID", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityImprovesSkill_SkillID",
                table: "ActivityImprovesSkill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ProfessionID",
                table: "Exercises",
                column: "ProfessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Involvements_QuestID",
                table: "Involvements",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Involvements_SimID_WorldID_Date",
                table: "Involvements",
                columns: new[] { "SimID", "WorldID", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_NeighborhoodDomesticUnits_NeighborhoodID",
                table: "NeighborhoodDomesticUnits",
                column: "NeighborhoodID");

            migrationBuilder.CreateIndex(
                name: "IX_NeighborhoodPlaces_NeighborhoodID",
                table: "NeighborhoodPlaces",
                column: "NeighborhoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_ActivityID",
                table: "Performances",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_PetLives_DomesticUnitID",
                table: "PetLives",
                column: "DomesticUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TypeID",
                table: "Pets",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionUpgradesSkill_SkillID",
                table: "ProfessionUpgradesSkill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestRequiresSkill_QuestID",
                table: "QuestRequiresSkill",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_SimLives_DomesticUnitID",
                table: "SimLives",
                column: "DomesticUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_SimSkills_SkillID",
                table: "SimSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_WorldID",
                table: "Travels",
                column: "WorldID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityImprovesSkill");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Involvements");

            migrationBuilder.DropTable(
                name: "NeighborhoodDomesticUnits");

            migrationBuilder.DropTable(
                name: "NeighborhoodPlaces");

            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "PetLives");

            migrationBuilder.DropTable(
                name: "ProfessionUpgradesSkill");

            migrationBuilder.DropTable(
                name: "QuestRequiresSkill");

            migrationBuilder.DropTable(
                name: "SimLives");

            migrationBuilder.DropTable(
                name: "SimSkills");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "DomesticUnits");

            migrationBuilder.DropTable(
                name: "Worlds");

            migrationBuilder.DropTable(
                name: "PetTypes");
        }
    }
}
