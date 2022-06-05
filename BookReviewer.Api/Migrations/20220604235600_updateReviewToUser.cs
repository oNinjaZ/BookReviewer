using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReviewer.Api.Migrations
{
    public partial class updateReviewToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Reviewer_UserId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviewer",
                table: "Reviewer");

            migrationBuilder.RenameTable(
                name: "Reviewer",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Reviewer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviewer",
                table: "Reviewer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Reviewer_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "Reviewer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
