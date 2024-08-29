using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class AuthorRefactoring2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_AuthorName",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BookAuthor");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Author",
                newName: "AuthorName");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "BookAuthor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorName" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_AuthorName",
                table: "BookAuthor",
                column: "AuthorName",
                principalTable: "Author",
                principalColumn: "AuthorName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_AuthorName",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Author",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "BookAuthor",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "BookAuthor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_AuthorName",
                table: "BookAuthor",
                column: "AuthorName",
                principalTable: "Author",
                principalColumn: "Name");
        }
    }
}
