using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSystem.Migrations
{
    public partial class positioncandidates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "candidates",
                table: "Positions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "candidates",
                table: "Positions");
        }
    }
}
