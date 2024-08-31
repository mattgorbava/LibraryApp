using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class SubscriberBookChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriberBook_Subscriber_PersonId",
                table: "SubscriberBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriberBook",
                table: "SubscriberBook");

            migrationBuilder.AddColumn<int>(
                name: "BorrowId",
                table: "SubscriberBook",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SubscriberPersonId",
                table: "SubscriberBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriberBook",
                table: "SubscriberBook",
                column: "BorrowId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberBook_SubscriberPersonId",
                table: "SubscriberBook",
                column: "SubscriberPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriberBook_Subscriber_SubscriberPersonId",
                table: "SubscriberBook",
                column: "SubscriberPersonId",
                principalTable: "Subscriber",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriberBook_Subscriber_SubscriberPersonId",
                table: "SubscriberBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriberBook",
                table: "SubscriberBook");

            migrationBuilder.DropIndex(
                name: "IX_SubscriberBook_SubscriberPersonId",
                table: "SubscriberBook");

            migrationBuilder.DropColumn(
                name: "BorrowId",
                table: "SubscriberBook");

            migrationBuilder.DropColumn(
                name: "SubscriberPersonId",
                table: "SubscriberBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriberBook",
                table: "SubscriberBook",
                columns: new[] { "PersonId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriberBook_Subscriber_PersonId",
                table: "SubscriberBook",
                column: "PersonId",
                principalTable: "Subscriber",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
