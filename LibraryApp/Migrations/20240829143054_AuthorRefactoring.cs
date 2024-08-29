using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class AuthorRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Subscriber_PersonId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Book_PersonId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Author");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "BookAuthor",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLent",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Author",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorName",
                table: "BookAuthor",
                column: "AuthorName");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_AuthorName",
                table: "BookAuthor",
                column: "AuthorName",
                principalTable: "Author",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_AuthorName",
                table: "BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthor_AuthorName",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "IsLent",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Author",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PersonId",
                table: "Book",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Subscriber_PersonId",
                table: "Book",
                column: "PersonId",
                principalTable: "Subscriber",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
