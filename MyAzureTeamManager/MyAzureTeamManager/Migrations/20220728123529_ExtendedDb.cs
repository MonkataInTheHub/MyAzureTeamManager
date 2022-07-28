using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAzureTeamManager.Migrations
{
    public partial class ExtendedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedbacKId",
                table: "Feedbacks",
                newName: "FeedbackId");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_TeamId",
                table: "Boards",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Teams_TeamId",
                table: "Boards",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Teams_TeamId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_TeamId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Boards");

            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "Feedbacks",
                newName: "FeedbacKId");
        }
    }
}
