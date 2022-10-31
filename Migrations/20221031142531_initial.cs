using Microsoft.EntityFrameworkCore.Migrations;

namespace HikerPals.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hikers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    AverageDailyMiles = table.Column<int>(nullable: false),
                    YearsExperience = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TName = table.Column<string>(maxLength: 50, nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    HikerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                    table.ForeignKey(
                        name: "FK_Trails_Hikers_HikerId",
                        column: x => x.HikerId,
                        principalTable: "Hikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hikers",
                columns: new[] { "Id", "Age", "AverageDailyMiles", "TrailName", "YearsExperience", "email" },
                values: new object[,]
                {
                    { 1, 45, 15, "Low Branch", 15, "littleJimmy@aol.com" },
                    { 2, 65, 7, "Ten Steps", 30, "ten@aol.com" },
                    { 3, 33, 4, "Coach", 2, "coach@aol.com" },
                    { 4, 35, 4, "The Captain", 2, "Cap@aol.com" }
                });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "Distance", "HikerId", "TName" },
                values: new object[] { 1, 2190.0, 1, "Appalacian Trail" });

            migrationBuilder.CreateIndex(
                name: "IX_Trails_HikerId",
                table: "Trails",
                column: "HikerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Hikers");
        }
    }
}
