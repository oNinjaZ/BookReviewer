using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReviewer.Api.Migrations
{
    public partial class update060422 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Reviewer_ReviewerId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Review",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ReviewerId",
                table: "Review",
                newName: "IX_Review_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Reviewer",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Reviewer_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "Reviewer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Reviewer_UserId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Reviewer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Review",
                newName: "ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId",
                table: "Review",
                newName: "IX_Review_ReviewerId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Book",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Reviewer_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "Reviewer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
