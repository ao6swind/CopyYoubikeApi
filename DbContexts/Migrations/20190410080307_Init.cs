using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YouBikeSites",
                columns: table => new
                {
                    SiteNumber = table.Column<int>(nullable: false),
                    SiteName = table.Column<string>(nullable: true),
                    ParkingSpaceCount = table.Column<int>(nullable: false),
                    IdelBikeCount = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Latitude = table.Column<float>(nullable: false),
                    Longtitude = table.Column<float>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YouBikeSites", x => x.SiteNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YouBikeSites");
        }
    }
}
