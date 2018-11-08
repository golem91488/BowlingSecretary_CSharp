using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BowlingSecretary.Migrations
{
    public partial class GameScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Round = table.Column<int>(nullable: false),
                    GameNumber = table.Column<int>(nullable: false),
                    Team1ID = table.Column<int>(nullable: true),
                    Team2ID = table.Column<int>(nullable: true),
                    LaneSet = table.Column<int>(nullable: false),
                    IsProcessed = table.Column<bool>(nullable: false),
                    IsPositionRound = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Game_Team_Team1ID",
                        column: x => x.Team1ID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Team_Team2ID",
                        column: x => x.Team2ID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BowlerScore",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BowlerID = table.Column<int>(nullable: true),
                    TeamID = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Handicap = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BowlerScore", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BowlerScore_Bowler_BowlerID",
                        column: x => x.BowlerID,
                        principalTable: "Bowler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BowlerScore_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BowlerScore_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BowlerScore_BowlerID",
                table: "BowlerScore",
                column: "BowlerID");

            migrationBuilder.CreateIndex(
                name: "IX_BowlerScore_GameID",
                table: "BowlerScore",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_BowlerScore_TeamID",
                table: "BowlerScore",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_Team1ID",
                table: "Game",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_Team2ID",
                table: "Game",
                column: "Team2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BowlerScore");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
