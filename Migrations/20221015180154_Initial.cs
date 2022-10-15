using Microsoft.EntityFrameworkCore.Migrations;

namespace HikerPals.Migrations
{
    public partial class Initial : Migration
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
                    YearsExperience = table.Column<int>(nullable: false)
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
                    TName = table.Column<string>(nullable: false),
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
                columns: new[] { "Id", "Age", "AverageDailyMiles", "TrailName", "YearsExperience" },
                values: new object[] { 1, 45, 15, "Low Branch", 15 });

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
